using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField, Tooltip("Reference to the Rigidbode2D")]
    private Rigidbody2D rb;


    [SerializeField, Tooltip("Reference to the trap script to listen to the event")]
    private FallingTrap _fallingTrapScript;


    private void OnEnable()
    {
        _fallingTrapScript.OnTrapSet += ReleaseTheTrap;
    }

    private void OnDisable()
    {
        _fallingTrapScript.OnTrapSet -= ReleaseTheTrap;
    }

    private void ReleaseTheTrap()
    {
        Debug.Log("RELEASE THE WEIGHTS");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null)
        {
            collision.collider.TryGetComponent(out IDamagable damagable);
            Debug.Log(damagable);
            damagable?.TakeDamage(_fallingTrapScript.TrapDamage);
        }
    }
}
