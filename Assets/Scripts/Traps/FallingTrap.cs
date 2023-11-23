using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    [field: Header("Ceiling Trigger settings")]
    [field: SerializeField, Tooltip("Reference to the ceilling")]
    public Transform Ceiling { get; private set; }


    [field: SerializeField, Tooltip("Adjust the dimenision of the trigger")]
    /// <summary>
    /// Adjust the dimenision of the trigger
    /// </summary>
    /// <value>Defaults to Vector2(1, 1)</value>
    public Vector2 TriggerDimensions { get; private set; } = new Vector2(1.0f, 1.0f);

    [SerializeField, Tooltip("Reference to the trigger size of the trap")]
    private BoxCollider2D _fallingTrapCollider;

    [field: SerializeField, Tooltip("The damage the trap cause to the target")]
    public float TrapDamage { get; private set; }


    public event Action OnTrapSet;


    /// <summary>
    /// A method that changes the trigger with the parameters exposed in the inspector
    /// </summary>
    /// <param name="height">The trigger height (defaults = 1)</param>
    /// <param name="width">The trigger width (defaults = 1)</param>
    public void ChaneTriggerParameters(float height = 1.0f, float width = 1.0f)
    {
        // // Get the component to change its values in the editor
        // _fallingTrapCollider = GetComponent<BoxCollider2D>();


        // yOffset calculation
        // divide by 2 to offset the center of the collider to the edge of the gameobject
        // Multiply by -1 to increase the height downward insteat of upward
        float yOffset = height / 2 * -1;

        if (_fallingTrapCollider != null)
        {
            _fallingTrapCollider.size = new Vector2(width, height);
            _fallingTrapCollider.offset = new Vector2(0.0f, yOffset);
        }
    }

    // Inspector GUI
    //---------------------------------------------------------------------------------------------
    public void OnValidate()
    {
        ChaneTriggerParameters(height: TriggerDimensions.y, width: TriggerDimensions.x);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_fallingTrapCollider.offset, _fallingTrapCollider.size);
    }

    //---------------------------------------------------------------------------------------------
    public void OnTriggerEnter2D()
    {
        Debug.Log("Ooooh, it's a trap!!");
        OnTrapSet?.Invoke();
    }
}
