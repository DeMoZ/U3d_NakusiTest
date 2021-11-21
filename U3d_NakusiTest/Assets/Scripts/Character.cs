using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterSettings _characterSettings = default;
    [SerializeField] private HpBar _hpBar = default;
    private float _health;
    private Action<GameObject> _onKill;

    public void Init(Action<GameObject> onKill)
    {
        _health = _characterSettings.Health;
        _hpBar.Set(1);
        _onKill += onKill;
    }

    public void SetDamage(float damage)
    {
        _health -= damage;
        if (_health < 0) _health = 0;
        _hpBar.Set(_health / _characterSettings.Health);

        Debug.Log($"{name} damaged -{damage}; hp = {_health}");
        if (_health <= 0)
            Kill();
    }

    private void Kill()
    {
        _onKill?.Invoke(gameObject);
        _onKill = null;
    }
}