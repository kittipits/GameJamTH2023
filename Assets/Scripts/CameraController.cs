using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform MapLeft;
    [SerializeField] Transform MapRight;
    [SerializeField] Transform MapTop;
    [SerializeField] Transform MapBottom;
    Transform target;
    Vector3 velocity = Vector3.zero;

    [Range(0, 1)] public float smoothTime;

    public Vector3 positionOffset;
    public Vector2 yLimit;
    public Vector2 xLimit;
    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        xLimit.x = MapLeft.position.x + halfWidth;
        xLimit.y = MapRight.position.x - halfWidth;
        yLimit.x = MapBottom.position.y + halfHeight;
        yLimit.y = MapTop.position.y - halfHeight;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + positionOffset;
        transform.position = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
