using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    public class BombMonoBehSpawner : AbstractMonoBehSpawner
    {
        [SerializeField] private int _count = 10;

        public override void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
            {
                var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy( Calculations.RandomPrefab(_prefabs), settings);
                var instance = entityManager.Instantiate(prefab);
                var position = new float3(Calculations.RandomPosition((-10,10),(0,0),(-10,10)));

                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }
}