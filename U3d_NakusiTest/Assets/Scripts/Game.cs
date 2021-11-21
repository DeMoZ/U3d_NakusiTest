using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameSettings _settings = default;
    [SerializeField] private Transform _floor = default;

    private void Start()
    {
        _floor.localScale = _settings.FloorExtents;

        var pool = new Pool();

        var wallSpawner = new WallSpawner(this, pool, _settings.WallsSettings, _settings.FloorExtents);
        var characterSpawner = new CharacterSpawner(this, pool, _settings.CharactersSettings, _settings.FloorExtents);
        var bombSpawner = new BombSpawner(this, pool, _settings.BombsSettings, _settings.FloorExtents);

        wallSpawner.Spawn();
        characterSpawner.Spawn();
        bombSpawner.Spawn();
    }
}