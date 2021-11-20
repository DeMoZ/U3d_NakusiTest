using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterSettings _characterSettings = default;

    private float _health;
    private Action<GameObject> _onKill;
    
    public void Init(Action<GameObject> onKill)
    {
        _health = _characterSettings.Health;
        _onKill += onKill;
    }
    
    public void SetDamage(float damage)
    {
        _health -= damage;
        
        Debug.Log($"{name} damaged -{damage}; hp = {_health}");
        if (_health <= 0)
            Kill();
    }

    private void Kill()
    {
        _onKill?.Invoke(gameObject);
        _onKill = null;
        Destroy(gameObject);
    }
}