using UnityEngine;

namespace UnityEcs
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Transform _floor = default;

        [SerializeField] private GameObject[] _botPrefabs = default;
        [SerializeField] private int _botsAmount = 10;
        [SerializeField] private GameObject[] _bombPrefabs = default;
        [SerializeField] private int _bombsAmount = 10;

        private void Start()
        {
            var floorBounds = _floor.GetComponent<Renderer>().bounds;

            var botSpawner = new BotMonoBehSpawner(_botPrefabs, floorBounds, _botsAmount);
            var bombSpawner = new BombMonoBehSpawner(_bombPrefabs, floorBounds, _bombsAmount);
            // var wallSpawner = Instantiate(wallMonoBehSpawnerPrefab);

            botSpawner.Spawn();
            bombSpawner.Spawn();
            // wallSpawner.Spawn();
        }
    }
}