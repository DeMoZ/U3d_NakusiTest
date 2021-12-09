using Unity.Collections;
using Unity.Entities;

namespace UnityEcs
{
    public class BoomSystem : SystemBase
    {
        /*protected override void OnUpdate()
        {
            var ecb = new EntityCommandBuffer(Allocator.TempJob);

            Entities.WithAll<BombMarker>().ForEach((Entity e, ref LifeTimeData lifeTimeData) =>
            {
                if (lifeTimeData.Value <= 0) 
                    ecb.DestroyEntity(e);
            }).ScheduleParallel();
            
            ecb.Dispose();
        }*/

        private EndSimulationEntityCommandBufferSystem m_EndSimEcb;

        protected override void OnCreate()
        {
            //We grab the EndSimulationEntityCommandBufferSystem to record our structural changes
            m_EndSimEcb = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            //We add "AsParallelWriter" when we create our command buffer because we want
            //to run our jobs in parallel
            var commandBuffer = m_EndSimEcb.CreateCommandBuffer().AsParallelWriter();

            //We now any entities with a DestroyTag and an AsteroidTag
            //We could just query for a DestroyTag, but we might want to run different processes
            //if different entities are destroyed, so we made this one specifically for Asteroids
            Entities
                .WithAll<BombMarker, LifeTimeData>()
                .ForEach((Entity entity, int nativeThreadIndex, ref LifeTimeData lifeTimeData) =>
                {
                    if (lifeTimeData.Value <= 0)

                        commandBuffer.DestroyEntity(nativeThreadIndex, entity);
                }).ScheduleParallel();

            //We then add the dependencies of these jobs to the EndSimulationEntityCOmmandBufferSystem
            //that will be playing back the structural changes recorded in this sytem
            m_EndSimEcb.AddJobHandleForProducer(Dependency);
        }
    }
}