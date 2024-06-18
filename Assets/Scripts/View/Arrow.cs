using DG.Tweening;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private ArrowTuningConfig _tuningConfig;
    [SerializeField] private Collider _collider;

    public void Tune(float targetLocalZ)
    {
        transform.DOLocalRotate(new Vector3(0, 0, targetLocalZ), _tuningConfig.GetDuration())
            .SetEase(_tuningConfig.GetEasing())
            .Play();
    }

    public Collider GetCollider() => _collider;

    public void OnMouseDrag()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit) && hit.transform == transform)
        {
            var mousePositionOnObject = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            transform.rotation = Quaternion.LookRotation(transform.forward, mousePositionOnObject - transform.position);
        }
    }
}
