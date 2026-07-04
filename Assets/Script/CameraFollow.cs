using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime = 0.2f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f);

    [Header("Camera Bounds")]
    [SerializeField] private Vector2 minPosition;
    
    [SerializeField] private Vector2 maxPosition;

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;

        float clampedX = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, offset.z);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            clampedPosition,
            ref velocity,
            smoothTime
        );
    }
}
