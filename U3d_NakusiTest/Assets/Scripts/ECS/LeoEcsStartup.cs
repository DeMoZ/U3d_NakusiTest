using Leopotam.Ecs;
using UnityEngine;

public class LeoEcsStartup : MonoBehaviour
{
   [SerializeField] private GameSettings _gameSettings = default;
   
   private EcsWorld _world;
   private EcsSystems _systems;
   
   private void Start()
   {
      _world = new EcsWorld();
      _systems = new EcsSystems(_world);

      RuntimeData runtimeData = new RuntimeData();
      
      _systems.Add(new SpawnObjectsSystem()).
         Inject(_gameSettings). 
         Inject(runtimeData).
         Init();
   }

   private void Update() => 
      _systems?.Run();

   private void OnDestroy()
   {
      _systems.Destroy();
      _systems = null;
      _world.Destroy();
      _world = null;
   }
}