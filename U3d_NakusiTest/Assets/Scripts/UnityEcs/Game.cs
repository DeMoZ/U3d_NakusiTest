using System;
using UnityEngine;

namespace UnityEcs
{
    public partial class Game : MonoBehaviour
    {
        [SerializeField] private GameSettings _settings = default;
        [SerializeField] private Transform _floor = default;

        [SerializeField] private AbstractMonoBehSpawner botMonoBehSpawnerPrefab = default;
        [SerializeField] private AbstractMonoBehSpawner bombMonoBehSpawnerPrefab = default;
        [SerializeField] private AbstractMonoBehSpawner wallMonoBehSpawnerPrefab = default;

        [SerializeField] private GameObject[] _botPrefabs = default;
        [SerializeField] private GameObject[] _bombPrefabs = default;

        private void Start()
        {
            //_floor.localScale = _settings.FloorExtents;

            var botSpawner = Instantiate(botMonoBehSpawnerPrefab);
            var bombSpawner = Instantiate(bombMonoBehSpawnerPrefab);
            // var wallSpawner = Instantiate(wallMonoBehSpawnerPrefab);

            var floorBounds = _floor.GetComponent<Renderer>().bounds;
            
            botSpawner.Init(_botPrefabs, floorBounds);
            bombSpawner.Init(_bombPrefabs, floorBounds);

            botSpawner.Spawn();
            bombSpawner.Spawn();
            // wallSpawner.Spawn();
        }
    }
}