using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityEcs
{
    public class BotMonoBehSpawner
    {
        private int _count;
        private BotEcs[] _prefabs;
        private Bounds _floorBounds;

        public BotMonoBehSpawner(BotEcs[] prefabs, Bounds floorBounds, int count)
        {
            _prefabs = prefabs;
            _floorBounds = floorBounds;
            _count = count;
        }

        public void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
            {
                var bot = _prefabs[Random.Range(0, _prefabs.Length)];
                var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bot.gameObject, settings);
                var instance = entityManager.Instantiate(prefab);
                entityManager.AddComponentData(instance, new HealthData { Value = bot.BotSettings.Health });

                var position = Calculations.RandomPosition(_floorBounds);
                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }
}