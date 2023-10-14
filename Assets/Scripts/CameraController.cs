using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;

    [Header("Axis Limitation")] public Vector2 yLimit;
    public Vector2 xLimit;
    
    private void Awake()
    {
        xLimit.x = transform.localPosition.x - 0.1f;
        xLimit.y = transform.localPosition.x + 18.0f + 0.1f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        transform.position = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void MoveToNewRoom(Transform newRoom)
    { 
        xLimit.x = newRoom.position.x - 0.1f;
        xLimit.x = newRoom.position.x + 0.1f;
    }
}
