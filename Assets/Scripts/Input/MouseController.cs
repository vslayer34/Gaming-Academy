using UnityEngine;
using UnityEngine.InputSystem;

public class MouseController : MonoBehaviour
{
    [SerializeField, Tooltip("Referance to the input tracker SO")]
    private SO_InputTracker inputTracker;

    private Camera _mainCamera;

    // reference to the currently clicked emeny
    private IClickable currentlyClicked;

    private void Start()
    {
        _mainCamera = Camera.main;
        Cursor.visible = false;
        inputTracker.OnRightMouseClick += MarkTheEnemy;
    }

    private void Update()
    {
        MouseWorldPosition = GetMouseWorldPosition();
        FollowMousePosition();
        inputTracker.mouseWorldPosition = MouseWorldPosition;
    }


    /// <summary>
    /// Transform the mouse screen position to the world position
    /// </summary>
    /// <returns>Vector3 of the mouse world position</returns>
    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        return new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
    }

    /// <summary>
    /// follow the position of the mouse in the world
    /// </summary>
    private void FollowMousePosition()
    {
        transform.position = MouseWorldPosition;
    }


    private void MarkTheEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(MouseWorldPosition, Vector3.zero);
        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out IClickable clickable))
            {
                currentlyClicked = clickable;
                currentlyClicked.MarkMe();
            }
        }
        else
        {
            Debug.Log("Right Click");
            currentlyClicked?.DeMarkMe();
            currentlyClicked = null;
        }
    }


    //----------------------------------------------------------------------------

    /// <summary>
    /// to store the mouse world position
    /// </summary>
    public Vector2 MouseWorldPosition { get; private set; }
}
