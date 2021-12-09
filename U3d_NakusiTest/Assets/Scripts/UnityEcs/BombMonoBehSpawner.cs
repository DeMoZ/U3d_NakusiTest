using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    public class BombMonoBehSpawner : AbstractMonoBehSpawner
    {
        [SerializeField] private BombEcs[] _prefabss;
        [SerializeField] private int _count = 10;

        public override void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
            {
                var bomb = _prefabss[Random.Range(0, _prefabss.Length)];
                var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bomb.gameObject, settings);
                var instance = entityManager.Instantiate(prefab);
                entityManager.AddComponentData(instance, new LifeTimeData { Value = bomb.Settings.LifeTime });
                entityManager.AddComponentData(instance, new BombTag());

                var position = Calculations.RandomPosition(_floorBounds);
                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }
}