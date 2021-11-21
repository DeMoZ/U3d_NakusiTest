using UnityEngine;

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
}