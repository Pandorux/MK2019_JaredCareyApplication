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
    bool isJumping;

    bool canJump
    {
        get
        {
            if(rigidBody.velocity.y > 0.25)
                return false;

            if(rigidBody.velocity.y < -0.25)
                return false;


            return true;
        }
    }

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

        #elif UNITY_ANDROID || UNITY_IOS 

            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if(touch.phase == TouchPhase.Began)
                {
                    Jump();
                }
            }

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
        if(canJump)
        {
            rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
}
