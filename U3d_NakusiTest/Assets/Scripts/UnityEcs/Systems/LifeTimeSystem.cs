using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    // [DisableAutoCreation]
    public class LifeTimeSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimCMB;
        private EntityManager _entityManager;

        protected override void OnCreate()
        {
            _endSimCMB = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override void OnUpdate()
        {
            var commandBuffer = _endSimCMB.CreateCommandBuffer().AsParallelWriter();
            var time = Time.DeltaTime;

            Entities
                .WithAll<LifeTimeData>()
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeTimeData lifeTimeData) =>
                {
                    lifeTimeData.Value -= time;

                    if (lifeTimeData.Value <= 0)
                    {
                        commandBuffer.AddComponent(nativeThreadIndex, entity, new DestroyTag());
                    }
                }).ScheduleParallel();

            Entities
                .WithAll<BombTag, DestroyTag>()
                .ForEach((Entity entity, int nativeThreadIndex, in BombTag bombTag, in Translation translation) =>
                {
                    var instance =   commandBuffer.Instantiate( nativeThreadIndex, bombTag.BoomArea);
                    commandBuffer.SetComponent(nativeThreadIndex ,instance, new Translation { Value = translation.Value });
                }).ScheduleParallel();

            _endSimCMB.AddJobHandleForProducer(Dependency);
        }
    }
}