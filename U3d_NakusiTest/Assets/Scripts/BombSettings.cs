using UnityEngine;

[CreateAssetMenu]
public class BombSettings: ScriptableObject
{
    public float LifeTime = 2;
    public float BoomRadius = 5;
    public float Damage = 4;
}