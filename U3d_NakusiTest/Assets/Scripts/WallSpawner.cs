using UnityEngine;

public class WallSpawner: AbstractSpawner
{
    private WallsSettings _settings;
    public WallSpawner(MonoBehaviour owner, Pool pool, WallsSettings settings, Vector3 settingsFloorExtents)
    {
        _owner = owner;
        _pool = pool;
        _settings = settings;
        /*_spawnTimer = 0;
        _floorExtents = floorExtents;
        _objects = new List<GameObject>();

        _types = settings.Types;
        _spawnDalay = settings.SpawnDalay;
        _spawnInterval = settings.SpawnInterval;
        _maxAmount = settings.MaxAmount;*/
    }

    public void Spawn()
    {
        // throw new System.NotImplementedException();
    }

    protected override void OnObjectSpawn(GameObject gameObject)
    {
        
        
    }
}