using Unity.Entities;

namespace UnityEcs
{
    [GenerateAuthoringComponent]
    public class HealthData : IComponentData
    {
        public float Value;
    }
}