using Unity.Entities;

namespace UnityEcs
{
    [UpdateAfter(typeof(LifeTimeSystem))]
    [UpdateAfter(typeof(BoomAreaSystem))]
    public class DestroySystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimCMB;

        protected override void OnCreate()
        {
            //We grab the EndSimulationEntityCommandBufferSystem to record our structural changes
            _endSimCMB = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            //We add "AsParallelWriter" when we create our command buffer because we want
            //to run our jobs in parallel
            var commandBuffer = _endSimCMB.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithAll<DestroyTag>()
                .ForEach((Entity entity, int nativeThreadIndex) =>
                {
                    commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                }).ScheduleParallel();

            _endSimCMB.AddJobHandleForProducer(Dependency);
        }
    }
}