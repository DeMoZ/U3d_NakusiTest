using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : AbstractSpawner
{
    private CharactersSettings _settings;

    public CharacterSpawner(MonoBehaviour owner, CharactersSettings settings, Vector3 floorExtents)
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
        var bomb = gameObject.GetComponent<Character>();
        bomb.Init(OnKill);
    }

    private void OnKill(GameObject gameObject)
    {
        _objects.Remove(gameObject);
    }
}