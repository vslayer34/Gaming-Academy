using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    [field: SerializeField, Tooltip("Reference to the ceilling")]
    public Transform Ceiling { get; private set; }

    private BoxCollider2D _faiilinTrapCollider;

    private void Start()
    {
        _faiilinTrapCollider = Ceiling.GetComponent<BoxCollider2D>();
    }


    public void ChaneTriggerParameters(int height)
    {
        // yOffset calculation
        // divide by 2 to offset the center of the collider to the edge of the gameobject
        // Multiply by -1 to increase the height downward insteat of upward
        float yOffset = height / 2 * -1;

        _faiilinTrapCollider.size = new Vector2(0.0f, height);
        _faiilinTrapCollider.offset = new Vector2(0.0f, yOffset);
    }
}
