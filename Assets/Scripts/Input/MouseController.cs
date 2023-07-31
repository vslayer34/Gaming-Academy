using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField, Tooltip("Referance to the input tracker SO")]
    private SO_InputTracker inputTracker;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
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

    //----------------------------------------------------------------------------

    /// <summary>
    /// to store the mouse world position
    /// </summary>
    public Vector2 MouseWorldPosition { get; private set; }
}
