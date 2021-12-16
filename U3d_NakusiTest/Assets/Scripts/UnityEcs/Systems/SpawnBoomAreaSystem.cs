using Unity.Entities;
using Unity.Transforms;

namespace UnityEcs
{
    [UpdateAfter(typeof(LifeTimeSystem))]
    public class SpawnBoomAreaSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimCMB;

        protected override void OnCreate()
        {
            _endSimCMB = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var commandBuffer = _endSimCMB.CreateCommandBuffer().AsParallelWriter();

            Entities
                .WithAll<BombTag, DestroyTag>()
                .ForEach((Entity entity, int nativeThreadIndex, in BombTag bombTag, in DamageTag damageTag,
                    in Translation translation) =>
                {
                    var instance = commandBuffer.Instantiate(nativeThreadIndex, bombTag.BoomArea);
                    commandBuffer.SetComponent(nativeThreadIndex, instance,
                        new Translation { Value = translation.Value });
                    commandBuffer.AddComponent(nativeThreadIndex, instance,
                        new DamageTag { Damage = damageTag.Damage });
                }).ScheduleParallel();

            _endSimCMB.AddJobHandleForProducer(Dependency);
        }
    }
}