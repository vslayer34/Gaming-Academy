using UnityEngine;

public class GroundDectector : MonoBehaviour
{
    [SerializeField, Tooltip("reference to the player controller script")]
    private SamirController samirControllerScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Reset the jump counter
        samirControllerScript.CurrentJumpCounter = 0;
        Debug.Log("OnTriggerEnter2D: " + samirControllerScript.CurrentJumpCounter);
    }
}
