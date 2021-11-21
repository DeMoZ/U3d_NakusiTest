using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Transform _hp = default;
    private Camera _camera;

    public void Start() => 
        _camera = Camera.main;

    void Update() => 
        transform.rotation = Quaternion.LookRotation(-_camera.transform.position);

    public void Set(float value) => 
        _hp.localScale = new Vector3(value, 1, 1);
}
 