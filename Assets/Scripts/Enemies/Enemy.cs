using UnityEngine;

public class Enemy : MonoBehaviour, IClickable
{
    protected Rigidbody2D enemyRB;

    //-------------------------------------------------------------------------------

    [field: Header("Waypoints")]
    [field: SerializeField, Tooltip("array of waypoints")]
    public Transform[] Waypoints { get; protected set; }

    //--------------------------------------------------------------------------------

    [Header("Enemy movement settings")]
    [SerializeField, Tooltip("Enemy speed")]
    protected float speed;

    [SerializeField, Tooltip("Show which way the character is heading")]
    protected bool isLookingRight = true;

    [SerializeField, Tooltip("Temperary untill the sprite is ready")]
    protected Transform bodyGameobject;

    //----------------------------------------------------------------------------------

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// move the rigid body according to speed and direction
    /// </summary>
    /// <param name="direction">direction of the movement 1: right, -1: left</param>
    public void Move(float direction)
    {
        if (!isLookingRight)
        {
            FlipSprite(180, 180);
        }
        else
        {
            FlipSprite();
        }
        enemyRB.position += speed * Time.fixedDeltaTime * Vector2.right * direction;
    }


    /// <summary>
    /// only in the testing phase
    /// </summary>
    /// <param name="xRotation">transform rotation x value. Default = 0</param>
    /// <param name="zRotation">transform rotation z value. Default = 0</param>
    protected void FlipSprite(float xRotation = 0, float zRotation = 0)
    {
        bodyGameobject.eulerAngles = new (xRotation, 0.0f, zRotation);
    }

    //----------------------------------------------------------------------------------------------------

    public bool IsMarked { get; set; }

    public virtual void MarkMe()
    {
        Debug.Log("I'm currently marked");
    }

    public virtual void DeMarkMe()
    {
        Debug.Log("I'm now free from your marking");
    }

    //-------------------------------------------------------------------------------------------------
}
