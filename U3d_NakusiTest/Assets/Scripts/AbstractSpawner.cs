using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpawner
{
    protected MonoBehaviour _owner;
    protected Vector3 _floorExtents;
    protected float _spawnTimer;
    protected List<GameObject> _objects;
    protected float _spawnDalay;
    protected int _maxAmount;
    protected GameObject[] _types;
    protected float _spawnInterval;

    protected GameObject SpawnRandomObject(Vector3 floorExtents, GameObject[] objects)
    {
        var goPrefab = objects[Random.Range(0, objects.Length)];
        var goRadius = goPrefab.GetComponent<Renderer>().bounds.extents.x;
        var position = Calculations.FindPosition(floorExtents, goRadius);

        var gameObject = GameObject.Instantiate(goPrefab, position, Quaternion.identity);

        return gameObject;
    }

    public void Spawn() =>
        _owner.StartCoroutine(IESpawn());

    private IEnumerator IESpawn()
    {
        yield return new WaitForSeconds(_spawnDalay);

        while (true)
        {
            _spawnTimer -= Time.deltaTime;
            if (_spawnTimer < 0) _spawnTimer = 0;

            if (_spawnTimer == 0 && _objects.Count < _maxAmount)
            {
                var gameObject = SpawnRandomObject(_floorExtents, _types);
                _objects.Add(gameObject);
                OnObjectSpawn(gameObject);
                _spawnTimer = _spawnInterval;
            }

            yield return null;
        }
    }

    protected abstract void OnObjectSpawn(GameObject gameObject);
}