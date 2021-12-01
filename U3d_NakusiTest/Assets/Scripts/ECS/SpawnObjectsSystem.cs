using Leopotam.Ecs;

public class SpawnObjectsSystem : IEcsInitSystem
{
    private EcsWorld _world;
    private GameSettings _gameSettings;
    
    public void Init()
    {
        EcsEntity objectEntity = _world.NewEntity();
    }
}