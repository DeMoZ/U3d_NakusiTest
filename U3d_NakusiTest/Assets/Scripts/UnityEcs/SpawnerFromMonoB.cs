using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityEcs
{
    public class SpawnerFromMonoB : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs = default;
        [SerializeField] private int countX = 10;
        [SerializeField] private int countY = 10;

        private void Start()
        {
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);

            for (var x = 0; x < countX; x++)
            {
                for (var y = 0; y < countY; y++)
                {
                    var prefab =
                        GameObjectConversionUtility.ConvertGameObjectHierarchy(RandomPrefab(_prefabs), settings);
                    var instance = entityManager.Instantiate(prefab);
                    var position = transform.TransformPoint(new float3(x * 1.3f,
                        //0, 
                        noise.cnoise(new float2(x, y) * 0.21f) * 2,
                        y * 1.3f));

                    entityManager.SetComponentData(instance, new Translation { Value = position });
                }
            }
        }

        private GameObject RandomPrefab(GameObject[] prefabs) =>
            prefabs[Random.Range(0, prefabs.Length)];
    }
}