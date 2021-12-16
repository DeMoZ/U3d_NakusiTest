using Unity.Entities;

namespace UnityEcs
{
    [UpdateAfter(typeof(SpawnBoomAreaSystem))]
    public class BoomAreaSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimCBS;

        protected override void OnCreate()
        {
            _endSimCBS = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = _endSimCBS.CreateCommandBuffer().AsParallelWriter();
            
            // check for physic trigger collisions
            Entities
                .WithAll<BoomAreaTag, DamageTag>()
                .ForEach((Entity entity, int nativeThreadIndex, in DamageTag damageTag) =>
                {
                    
                }).ScheduleParallel();


            // then boom area will be destroyed by DestroySystem


        }
        
        //trigg
    }
}