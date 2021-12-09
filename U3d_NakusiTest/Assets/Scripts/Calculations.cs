using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Calculations
{
    public static Vector3 FindPosition(Vector3 floorExtents, float objectRadius)
    {
        var position = new Vector3(Random.Range(-floorExtents.x / 2, floorExtents.x / 2),
            1,
            Random.Range(-floorExtents.z / 2, floorExtents.z / 2));

        if (IsOverlaping(position, objectRadius))
            return FindPosition(floorExtents, objectRadius);
        else
            return position;
    }

    public static bool IsOverlaping(Vector3 center, float radius)
    {
        var hitColliders = new Collider[Constants.NonAllocColliderAmount];
        Physics.OverlapSphereNonAlloc(center, radius, hitColliders);

        foreach (var c in hitColliders)
        {
            if (c != null && c.TryGetComponent(out OverlapableMarker o))
                return true;
        }

        return false;
    }

    public static GameObject RandomPrefab(GameObject[] prefabs) =>
        prefabs[Random.Range(0, prefabs.Length)];

    public static float3 RandomPosition(
        (int min, int max) xRange,
        (int min, int max) yRange,
        (int min, int max) zRange)
    {
        return new float3(
            Random.Range(xRange.min, xRange.max),
            Random.Range(yRange.min, yRange.max),
            Random.Range(zRange.min, zRange.max));
    }

    public static float3 RandomPosition(Bounds bounds)
    {
        var center = bounds.center.x - bounds.extents.x;
        return new float3(
            Random.Range(bounds.center.x - bounds.extents.x, bounds.center.x + bounds.extents.x),
            bounds.center.y + bounds.extents.y,
            Random.Range(bounds.center.z - bounds.extents.z, bounds.center.z + bounds.extents.z));
    }
}