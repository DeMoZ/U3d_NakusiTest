using Unity.Entities;
using UnityEngine;

namespace UnityEcs
{
    // [DisableAutoCreation]
    public class LifeTimeSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimCMB;

        protected override void OnCreate()
        {
            _endSimCMB = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
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

            _endSimCMB.AddJobHandleForProducer(Dependency);
        }
    }
}