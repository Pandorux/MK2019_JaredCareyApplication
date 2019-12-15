using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The object that the camera is following.")]
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector2 cameraPos = target.position;
        cameraPos = new Vector2(cameraPos.x - cameraOffset.x, cameraPos.y - cameraOffset.y);

        transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraOffset.z);
    }
}
