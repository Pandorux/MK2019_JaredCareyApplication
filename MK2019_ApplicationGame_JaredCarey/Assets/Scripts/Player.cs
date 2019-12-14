using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The player's default movement speed")]
    [Range(0, 5)]
    public float movementSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float translate = movementSpeed * Time.deltaTime;
        Vector3 playerPos = transform.position;

        playerPos = new Vector3(playerPos.x + translate, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }
}
