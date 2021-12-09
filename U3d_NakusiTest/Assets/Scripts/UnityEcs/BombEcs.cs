using UnityEngine;

namespace UnityEcs
{
    public class BombEcs : MonoBehaviour
    {
        [SerializeField] private BombSettings _bombSettings = default;
        public BombSettings Settings => _bombSettings;
    }
}