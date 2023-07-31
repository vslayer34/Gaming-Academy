using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new input tracker", menuName = "Managers/Input Tracker")]
public class SO_InputTracker : ScriptableObject
{
    public float inputDirection;
    public Vector2 mousePosition;
    public Vector3 mouseWorldPosition;

    public Action OnJumpPressed;
    public Action OnPrimaryAttackPressed;
}
