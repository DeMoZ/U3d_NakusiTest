using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace UnityEcs
{
    public class BombMonoBehSpawner
    {
        private readonly int _count;
        private readonly GameObject[] _prefabs;

        private readonly Bounds _floorBounds;

        public BombMonoBehSpawner(GameObject[] prefabs, Bounds floorBounds, int count)
        {
            _prefabs = prefabs;
            _floorBounds = floorBounds;
            _count = count;
        }

        public void Spawn()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var i = 0; i < _count; i++)
                SpawnEntity(settings, entityManager);
        }

        private void SpawnEntity(GameObjectConversionSettings settings, EntityManager entityManager)
        {
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            var entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab.gameObject, settings);
            var instance = entityManager.Instantiate(entity);

            var position = Calculations.RandomPosition(_floorBounds);
            entityManager.SetComponentData(instance, new Translation { Value = position });
        }
    }
}