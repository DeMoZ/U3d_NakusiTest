using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace UnityEcs
{
    public class BombSpawnSystem : SystemBase
    {
        // private BeginSimulationEntityCommandBufferSystem _eCBS;

        private float _delayTimer;
        private float _spawnTimer;
        private EntityManager _entityManager;
        private GameObjectConversionSettings _settings;

        protected override void OnCreate()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
           // _eCBS = World.GetOrCreateSystem<BeginSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var maxAmount = 0;

            var spawnInterval = 0f;
            var spawnDelay = 0f;
           
            EntityQuery query = GetEntityQuery(ComponentType.ReadOnly<BombTag>());
            int countEntities = query.CalculateEntityCount();
            countEntities =  UnityEcs.GameEcs.Instance.BombsAmount - countEntities;
            countEntities = countEntities < 0 ? 0 : countEntities;

             for (var i = 0; i < countEntities; i++)
             {
                 var prefab = GameEcs.Instance.BombPrefabs[UnityEngine.Random.Range(0, GameEcs.Instance.BombPrefabs.Length)];
                 var entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab.gameObject, _settings);
                 var instance = _entityManager.Instantiate(entity);
                 var prefabPosition = prefab.transform.position;
                 var offset = new float3(prefabPosition.x, prefabPosition.y, prefabPosition.z);
                 var position = Calculations.RandomPosition(GameEcs.Instance.FloorBounds) + offset;
                 _entityManager.SetComponentData(instance, new Translation { Value = position });
             }
        }
    }
}