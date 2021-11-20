using UnityEngine;

[CreateAssetMenu]
public class GameSettings : ScriptableObject
{
    public Vector3 FloorExtents = new Vector3(7.5f, 0.05f, 7.5f);
    public WallsSettings WallsSettings;
    public CharactersSettings CharactersSettings;
    public BombsSettings BombsSettings;
}

[System.Serializable]
public class WallsSettings
{
    public int MaxAmount = 5;
    public float MaxWidth = 4;
}

[System.Serializable]
public class CharactersSettings
{
    public int MaxAmount = 3;
    public float SpawnDalay = 3f;
    public float SpawnInterval = 0.5f;
    public GameObject[] Types;
}

[System.Serializable]
public class BombsSettings
{
    public int MaxAmount = 1;
    public float SpawnDalay = 3f;
    public float SpawnInterval = 1f;
    public GameObject[] Types;
    public Vector2 RandomSizeRange = new Vector2(0.1f, 1f);
}