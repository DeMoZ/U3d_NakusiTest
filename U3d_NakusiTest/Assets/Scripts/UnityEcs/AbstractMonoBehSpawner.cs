using UnityEngine;

namespace UnityEcs
{
    public abstract class AbstractMonoBehSpawner : MonoBehaviour
    {
        protected Bounds _floorBounds;
        protected GameObject[] _prefabs;
        
        public abstract void Spawn();

        public void Init(GameObject[] prefabs, Bounds floorBounds)
        {
            _prefabs = prefabs;
            _floorBounds = floorBounds;
        }
    }
}