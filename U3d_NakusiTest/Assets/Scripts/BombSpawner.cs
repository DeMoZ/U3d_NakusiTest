using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner: AbstractSpawner
{
    private BombsSettings _settings;

    public BombSpawner(Game owner, BombsSettings settings, Vector3 floorExtents)
    {
        _owner = owner;
        _settings = settings;
        _spawnTimer = 0;
        _floorExtents = floorExtents;
        _objects = new List<GameObject>();

        _types = settings.Types;
        _spawnDalay = settings.SpawnDalay;
        _spawnInterval = settings.SpawnInterval;
        _maxAmount = settings.MaxAmount;
    }

    protected override void OnObjectSpawn(GameObject gameObject)
    {
        var bomb = gameObject.GetComponent<Bomb>();
        bomb.Init(OnBoom);
    }

    private void OnBoom(GameObject gameObject)
    {
        // send camera shake event

        _objects.Remove(gameObject);
    }
}