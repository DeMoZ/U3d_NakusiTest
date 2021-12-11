using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityEcs
{
    public class BotSpawner
    {
        private int _count;
        private GameObject[] _prefabs;
        private Bounds _floorBounds;

        public BotSpawner(GameObject[] prefabs, Bounds floorBounds, int count)
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
                var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
                var entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, settings);
                var instance = entityManager.Instantiate(entity);

                var position = Calculations.RandomPosition(_floorBounds);
                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }
}