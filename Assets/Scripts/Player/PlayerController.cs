using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("where to get the input")]
    protected SO_InputTracker inputTracker;

    protected float movementDirection;
    protected Rigidbody2D playerRigidBody;

    [Header("Movement Values")]
    [SerializeField]
    protected float speed = 10.0f;

    //-------------------------------------------------------------------------------



    /// <summary>
    /// Move the character according to the input
    /// </summary>
    protected void Move()
    {
        playerRigidBody.position += new Vector2(movementDirection * Time.fixedDeltaTime * speed, 0.0f);
    }

}
