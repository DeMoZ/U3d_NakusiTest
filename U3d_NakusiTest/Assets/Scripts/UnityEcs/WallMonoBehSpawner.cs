using UnityEngine;

namespace UnityEcs
{
    public class WallMonoBehSpawner
    {
        private int _count;
        private WallEcs[] _prefabs;
        private Bounds _floorBounds;


        public void Init(WallEcs[] prefabs, Bounds floorBounds, int count)
        {
            _prefabs = prefabs;
            _floorBounds = floorBounds;
            _count = count;
        }
    }
}