using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    public class BombMonoBehSpawner
    {
        private readonly int _count;
        private readonly BombEcs[] _prefabs;

        private readonly Bounds _floorBounds;
        //private readonly MonoBehaviour _owner;

        public BombMonoBehSpawner(BombEcs[] prefabs, Bounds floorBounds, int count)
        {
            _prefabs = prefabs;
            _floorBounds = floorBounds;
            _count = count;
            //  _owner = owner;
        }

        public void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
                SpawnEntity(settings, entityManager);

            // _owner.StartCoroutine(IESpawn(entityManager, settings));
        }

        /*
        private IEnumerator IESpawn(EntityManager entityManager, GameObjectConversionSettings settings)
        {
            while (true)
            {
                yield return null;

                if (entityManager.EntityCapacity < _count) 
                    SpawnEntity(settings, entityManager);
            }
        }
        */

        private void SpawnEntity(GameObjectConversionSettings settings, EntityManager entityManager)
        {
            var bomb = _prefabs[Random.Range(0, _prefabs.Length)];
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(bomb.gameObject, settings);
            var instance = entityManager.Instantiate(prefab);
            entityManager.AddComponentData(instance, new LifeTimeData { Value = bomb.Settings.LifeTime });
            entityManager.AddComponentData(instance, new BombTag());

            var position = Calculations.RandomPosition(_floorBounds);
            entityManager.SetComponentData(instance, new Translation { Value = position });
        }
    }
}