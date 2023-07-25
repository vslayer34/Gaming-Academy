using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new input tracker", menuName = "Managers/Input Tracker")]
public class SO_InputTracker : ScriptableObject
{
    public float inputDirection;
    public Action OnJumpPressed;
}
