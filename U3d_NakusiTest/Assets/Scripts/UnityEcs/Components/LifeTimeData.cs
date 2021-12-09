using Unity.Entities;
using System;

namespace UnityEcs
{
    [Serializable]
    public struct LifeTimeData : IComponentData
    {
        public float Value;
    }
}