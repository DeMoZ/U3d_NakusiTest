using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityEcs
{
    public class BombMonoBehSpawner : AbstractMonoBehSpawner
    {
        [SerializeField] private BombEcs[] _prefabs;
        [SerializeField] private int _count = 10;

        public override void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
            {
                var bomb = _prefabs[Random.Range(0, _prefabs.Length)];
                var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bomb.gameObject, settings);
                var instance = entityManager.Instantiate(prefab);
                entityManager.AddComponentData(instance, new LifeTimeData { Value = bomb.Settings.LifeTime });
                entityManager.AddComponentData(instance, new BombTag());

                var position = new float3(Calculations.RandomPosition((-10, 10), (0, 0), (-10, 10)));
                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }
}