using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private WallSettings _wallSettings = default;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));
        StartCoroutine(WideWall());
    }

    private IEnumerator WideWall()
    {
        while (transform.localScale.x < _wallSettings.Width)
        {
            var scale = transform.localScale + Vector3.right * Time.deltaTime * _wallSettings.GrowSpeed;

            if (WillOverlap(scale))
                yield break;

            transform.localScale = scale;
            yield return null;
        }
    }

    private bool WillOverlap(Vector3 scale)
    {
        var hitColliders = new Collider[Constants.NonAllocColliderAmount];
        Physics.OverlapBoxNonAlloc(transform.position, scale / 2, hitColliders);

        foreach (var c in hitColliders)
        {
            if (c != null && c.gameObject != gameObject && c.TryGetComponent(out OverlapableMarker o))
                return true;
        }

        return false;
    }
}