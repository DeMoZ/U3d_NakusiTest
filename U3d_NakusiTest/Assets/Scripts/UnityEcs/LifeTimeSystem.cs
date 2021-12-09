using Unity.Entities;

namespace UnityEcs
{
    // [DisableAutoCreation]
    public class LifeTimeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var time = Time.DeltaTime;
            Entities.
                WithAll<LifeTimeData>().
                ForEach((Entity e, ref LifeTimeData lifeTimeData) =>
            {
                lifeTimeData.Value -= time;

                if (lifeTimeData.Value < 0)
                    lifeTimeData.Value = 0;
            }).ScheduleParallel();
        }
    }
}