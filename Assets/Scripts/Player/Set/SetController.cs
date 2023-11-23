using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : PlayerController
{
    [Header("Floating Settings")]
    [SerializeField, Tooltip("floating value")]
    private float _floatingDistance;

    [SerializeField, Tooltip("Floating Collider")]
    private BoxCollider2D _floatingBoxCollider;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movementDirection = inputTracker.inputDirection;
    }

    private void FixedUpdate()
    {
        Move();
        SetFloatingDistance();
    }


    /// <summary>
    /// Draw a ray to the ground and elavate the character y position
    /// </summary>
    private void SetFloatingDistance()
    {
        _floatingBoxCollider.size = new Vector2(_floatingBoxCollider.size.x, _floatingDistance);
    }

    /// <summary>
    /// gets the size of the floating collider
    /// </summary>
    /// <value></value>
    public float FloatingBoxColliderSize { get => _floatingBoxCollider.size.x; }
}
