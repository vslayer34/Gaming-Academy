using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField, Tooltip("where the input values and events are stored")]
    private SO_InputTracker inputTracker;


    private PlayerInputActions playerActions;

    public float InputDirection {  get; private set; }

    private void Awake()
    {
        playerActions = new PlayerInputActions();
    }


    private void Start()
    {
        playerActions.Player.Enable();
        playerActions.Player.Jump.performed += Jump_performed;
        playerActions.Player.PrimaryAttack.performed += PrimaryAttack_performed;
    }

    private void PrimaryAttack_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnPrimaryAttackPressed?.Invoke();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnJumpPressed?.Invoke();
    }

    private void Update()
    {
        InputDirection = playerActions.Player.Movement.ReadValue<float>();
        inputTracker.inputDirection = InputDirection;
    }
}
