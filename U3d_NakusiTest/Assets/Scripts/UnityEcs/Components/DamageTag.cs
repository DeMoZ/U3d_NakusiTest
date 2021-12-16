using Unity.Entities;

namespace UnityEcs
{
    [GenerateAuthoringComponent]
    public struct DamageTag : IComponentData
    {
        public float Damage;
    }
}