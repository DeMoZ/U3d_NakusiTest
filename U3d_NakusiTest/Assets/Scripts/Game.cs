using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private GameSettings _settings = default;
    [SerializeField] private Transform _floor = default;

    private void Start()
    {
        _floor.localScale = _settings.FloorExtents;

        var wallSpawner = new WallSpawner(this, _settings.WallsSettings, _settings.FloorExtents);
        var characterSpawner =
            new CharacterSpawner(this, _settings.CharactersSettings, _settings.FloorExtents);
        var bombSpawner = new BombSpawner(this, _settings.BombsSettings, _settings.FloorExtents);

        wallSpawner.Spawn();
        characterSpawner.Spawn();
        bombSpawner.Spawn();
    }
}