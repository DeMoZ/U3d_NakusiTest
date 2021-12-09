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

            // _wallSpawner.Init(_settings.FloorExtents);
            // _botSpawner.Init(_settings.FloorExtents);
            // _bombSpawner.Init(_settings.FloorExtents);

            var botSpawner = Instantiate(botMonoBehSpawnerPrefab);
            var bombSpawner = Instantiate(bombMonoBehSpawnerPrefab);
            // var wallSpawner = Instantiate(wallMonoBehSpawnerPrefab);

            botSpawner.Init(_botPrefabs);
            bombSpawner.Init(_bombPrefabs);

            botSpawner.Spawn();
            bombSpawner.Spawn();
            // wallSpawner.Spawn();
        }
    }
}