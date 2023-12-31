using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField, Tooltip("where the input values and events are stored")]
    private SO_InputTracker inputTracker;


    private PlayerInputActions playerActions;

    /// <summary>
    /// Movement Direction
    /// </summary>
    public float InputDirection {  get; private set; }
    /// <summary>
    /// Mouse Position in the screen
    /// </summary>
    public Vector2 MousePosition { get; private set; }

    private void Awake()
    {
        playerActions = new PlayerInputActions();
    }


    private void Start()
    {
        playerActions.Player.Enable();

        // Jump and primary control actions except movement actions
        playerActions.Player.Jump.performed += Jump_performed;
        playerActions.Player.PrimaryAttack.performed += PrimaryAttack_performed;
        playerActions.Player.Mark.performed += Mark_performed;

        // switch character through buttons actions
        playerActions.Player.NextCharacter.performed += NextCharacter_performed;
        playerActions.Player.PreviouseCharacter.performed += PreviouseCharacter_performed;

        // Radial Wheel Actions
        playerActions.Player.RadialWheel.performed += RadialWheel_performed;
        playerActions.Player.RadialWheel.canceled += RadialWheel_canceled;
    }

    private void OnDisable()
    {
        // Jump and primary control actions except movement actions
        playerActions.Player.Jump.performed -= Jump_performed;
        playerActions.Player.PrimaryAttack.performed -= PrimaryAttack_performed;
        playerActions.Player.Mark.performed -= Mark_performed;

        // switch character through buttons actions
        playerActions.Player.NextCharacter.performed -= NextCharacter_performed;
        playerActions.Player.PreviouseCharacter.performed -= PreviouseCharacter_performed;

        // Radial Wheel Actions
        playerActions.Player.RadialWheel.performed -= RadialWheel_performed;
        playerActions.Player.RadialWheel.canceled -= RadialWheel_canceled;
    }

    private void Mark_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnRightMouseClick?.Invoke();
    }

    private void PrimaryAttack_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnPrimaryAttackPressed?.Invoke();
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnJumpPressed?.Invoke();
    }

    private void NextCharacter_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnNextCharacterPressed?.Invoke();
    }

    private void PreviouseCharacter_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnPreviousCharacterPressed?.Invoke();
    }

    private void RadialWheel_performed(InputAction.CallbackContext obj)
    {
        inputTracker.OnRadialWheelPressed?.Invoke();
    }

    private void RadialWheel_canceled(InputAction.CallbackContext obj)
    {
        inputTracker.OnRadialWheelCanceled?.Invoke();
    }

    private void Update()
    {
        InputDirection = playerActions.Player.Movement.ReadValue<float>();
        inputTracker.inputDirection = InputDirection;

        MousePosition = playerActions.Player.Look.ReadValue<Vector2>();
        inputTracker.mousePosition = MousePosition;
    }
}
