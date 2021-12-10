using Unity.Entities;

namespace UnityEcs
{
    [GenerateAuthoringComponent]
    public struct LifeTimeData : IComponentData
    {
        public float Value;
    }
}