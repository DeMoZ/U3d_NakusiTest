using System;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private BombSettings _bombSettings = default;
    
    private Pool _pool;
    private Action<GameObject> _onBoom;
    public void Init(Action<GameObject> onBoom)
    {
        _onBoom += onBoom;
        Invoke(nameof(Boom), _bombSettings.LifeTime);
    }

    private void Boom()
    {
        var overlapedObjects = CollectOverlapedObjects();

        foreach (var go in overlapedObjects)
        {
            if (BehindWall(go))
                continue;
            
            if (go.TryGetComponent(out Character c)) 
                c.SetDamage(_bombSettings.Damage);
        }
        
        Kill();
    }

    private bool BehindWall(GameObject go)
    {
        RaycastHit hit
            ;
        if (Physics.Raycast(transform.position, go.transform.position, out hit))
            if (hit.transform.TryGetComponent(out Wall w))
                return true;

        return false;
    }

    private List<GameObject> CollectOverlapedObjects()
    {
        var objects = new List<GameObject>();
        var hitColliders = new Collider[30];
        Physics.OverlapSphereNonAlloc(transform.position, _bombSettings.BoomRadius, hitColliders);

        foreach (var c in hitColliders)
        {
            if (c != null && c.TryGetComponent(out DamagebleMarker o))
                objects.Add(c.gameObject);
        }

        return objects;
    }
    
    private void Kill()
    {
        _onBoom?.Invoke(gameObject);
        _onBoom = null;
    }
}