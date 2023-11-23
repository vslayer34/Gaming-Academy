using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamirController : PlayerController
{
    //--------------------------------------------------------------------------------

    [Header("Jump Settings")]
    [SerializeField]
    private float jumpForce = 200.0f;

    [SerializeField, Tooltip("the limit of number of jumps")]
    private int maxJumpCounter = 1;

    [SerializeField, Tooltip("Ground Collider")]
    private Transform groundDetection;

    private int currentJumpCounter;
    public int CurrentJumpCounter
    {
        get => currentJumpCounter;
        set { currentJumpCounter = value; }
    }

    //-------------------------------------------------------------------------------

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        inputTracker.OnJumpPressed = Jump;
    }

    private void Update()
    {
        movementDirection = inputTracker.inputDirection;
    }


    private void FixedUpdate()
    {
        Move();
    }

    //-------------------------------------------------------------------------------

    /// <summary>
    /// Makes the player jump when OnJumpPressed event is fired
    /// </summary>
    private void Jump()
    {
        if (currentJumpCounter < maxJumpCounter)
        {
            playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentJumpCounter++;
        }
    }
}
