using Unity.Entities;

namespace UnityEcs
{
    [UpdateAfter(typeof(LifeTimeSystem))]
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

            //We now any entities with a DestroyTag and an AsteroidTag
            //We could just query for a DestroyTag, but we might want to run different processes
            //if different entities are destroyed, so we made this one specifically for Asteroids
            Entities
                .WithAll<BombTag, LifeTimeData>()
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeTimeData lifeTimeData) =>
                {
                    if (lifeTimeData.Value <= 0)

                        commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                }).ScheduleParallel();

            //We then add the dependencies of these jobs to the EndSimulationEntityCOmmandBufferSystem
            //that will be playing back the structural changes recorded in this sytem
            _endSimCMB.AddJobHandleForProducer(Dependency);
        }
    }
}