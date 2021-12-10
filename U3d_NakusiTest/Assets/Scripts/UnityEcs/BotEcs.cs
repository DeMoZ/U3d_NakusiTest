using UnityEngine;

namespace UnityEcs
{
    public class BotEcs : MonoBehaviour
    {
        [SerializeField] public CharacterSettings _botSettings= default;
        public CharacterSettings BotSettings => _botSettings;
    }
}