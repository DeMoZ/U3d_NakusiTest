using Unity.Entities;
using UnityEngine;

namespace UnityEcs
{
    public class GameEcs : MonoBehaviour
    {
        public static GameEcs Instance;

        [SerializeField] private Transform _floor = default;

        [field: SerializeField] public GameObject[] BotPrefabs { get; private set; } = default;
        [field: SerializeField] public int BotsAmount { get; private set; } = 10;
        [field: SerializeField] public GameObject[] BombPrefabs { get; private set; } = default;
        [field: SerializeField] public int BombsAmount { get; private set; } = 10;
        public Bounds FloorBounds { get; private set; }

        private void Awake() =>
            Instance = this;

        private void Start()
        {
            FloorBounds = _floor.GetComponent<Renderer>().bounds;

            var botSpawner = new BotSpawner(BotPrefabs, FloorBounds, BotsAmount);
            // var bombSpawner = new BombSpawner(_bombPrefabs, floorBounds, _bombsAmount);
            // var wallSpawner = Instantiate(wallMonoBehSpawnerPrefab);

            botSpawner.Spawn();
            // wallSpawner.Spawn();
        }
    }
}