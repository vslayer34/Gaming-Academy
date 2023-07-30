using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("where to get the input")]
    protected SO_InputTracker inputTracker;

    [SerializeField, Tooltip("Referance to the character sprite")]
    protected SpriteRenderer sprite;

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
        // flip the sprite
        switch (movementDirection)
        {
            case 1:
                sprite.flipX = false;
                break;
            case -1:
                sprite.flipX = true;
                break;
        }
        playerRigidBody.position += new Vector2(movementDirection * Time.fixedDeltaTime * speed, 0.0f);
        
    }

}
