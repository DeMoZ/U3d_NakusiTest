using UnityEngine;

public class WallSpawner
{
    private MonoBehaviour _owner;

    public WallSpawner(MonoBehaviour owner, WallsSettings settings, Vector3 settingsFloorExtents)
    {
        _owner = owner;
    }

    public void Spawn()
    {
        // throw new System.NotImplementedException();
    }
}