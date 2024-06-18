using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public void OnMouseDrag()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit) && hit.transform == transform)
        {
            var mousePositionOnObject = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            transform.rotation = Quaternion.LookRotation(transform.forward, mousePositionOnObject - transform.position);
        }
    }
}
