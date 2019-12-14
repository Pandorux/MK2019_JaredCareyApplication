using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Tooltip("The player's default movement speed")]
    [Range(0, 10)]
    public float movementSpeed = 1;

    [Tooltip("How high the player will jump")]
    [Range(0, 10)]
    public float jumpForce = 5;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        Movement();
    }

    void PlayerInput()
    {
        #if UNITY_EDITOR

            if(Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.UpArrow)
            || Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("PC Input Detected");
                Jump();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
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
        Vector2 playerPos = transform.position;

        playerPos = new Vector2(playerPos.x + translate, playerPos.y);
        transform.position = playerPos;
    }

    void Jump()
    {

        rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        // if (rigidBody.velocity.y < 0)
        // {
        //     rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        // }
        // else if (rigidBody.velocity.y > 0)
        // {
        //     rigidBody.velocity += Vector2.up * Physics2D.gravity.y * (2f - 1) * Time.deltaTime;
        // }
    }
}
