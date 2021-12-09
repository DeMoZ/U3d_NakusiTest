using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    public class BotMonoBehSpawner : AbstractMonoBehSpawner
    {
        [SerializeField] private int _count = 10;

        public override void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
            {
                var entity = GameObjectConversionUtility.ConvertGameObjectHierarchy( Calculations.RandomPrefab(_prefabs), settings);
        
                var instance = entityManager.Instantiate(entity);
                var position = new float3(Calculations.RandomPosition((-10, 10), (0, 0), (-10, 10)));

                entityManager.SetComponentData(instance, new Translation { Value = position });
            }
        }
    }

    public struct BotData : IComponentData
    {
        
    }

    [DisableAutoCreation]
    public class BotLifeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((Entity e, ref BotData botData) =>
            {
                
            }).Run();
        }
    }
}