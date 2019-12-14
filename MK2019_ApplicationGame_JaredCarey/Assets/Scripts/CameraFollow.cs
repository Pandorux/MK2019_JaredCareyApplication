using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The object that the camera is following.")]
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector2 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        Vector2 cameraPos = target.position;
        cameraPos = cameraPos - cameraOffset;

        // TODO: Make this more dynamic when needed
        transform.position = new Vector3(cameraPos.x, cameraPos.y, -10);
    }
}
