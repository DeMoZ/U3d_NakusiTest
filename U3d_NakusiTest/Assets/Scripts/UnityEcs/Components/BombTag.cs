using Unity.Entities;

namespace UnityEcs
{
    [GenerateAuthoringComponent]
    public struct BombTag : IComponentData
    {
        public Entity BoomArea;
    }
}