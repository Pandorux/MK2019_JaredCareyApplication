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

    void PlayerInput()
    {
        #if UNITY_EDITOR

            if(Input.getKeyDown(Keycode.Space) 
            || Input.getKeyDown(Keycode.UpArrow)
            || Input.getKeyDown(Keycode.W))
            {
                // TODO: Jump
            }

            if(Input.getKeyDown(Keycode.Escape))
            {
                // TODO: Pause the Game
            }

        #elif UNITY_ANDROID

            // TODO: Mobile Input

        #endif 
    }

    void Movement()
    {
        float translate = movementSpeed * Time.deltaTime;
        Vector3 playerPos = transform.position;

        playerPos = new Vector3(playerPos.x + translate, playerPos.y, playerPos.z);
        transform.position = playerPos;
    }
}
