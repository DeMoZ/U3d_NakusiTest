using UnityEngine;

namespace UnityEcs
{
    public abstract class AbstractMonoBehSpawner : MonoBehaviour
    {
        protected GameObject[] _prefabs;
        
        public abstract void Spawn();

        public void Init(GameObject[] prefabs) => 
            _prefabs = prefabs;
    }
}