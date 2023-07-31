using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IAttack
{
    [SerializeField, Tooltip("referance to input tracker SO")]
    protected SO_InputTracker _inputTracker;


    [Header("Damage Values")]
    [SerializeField, Tooltip("damage value of the attack")]
    protected float _damage;
    
    [SerializeField, Tooltip("Attack Radiuse")]
    protected Vector2 _attackRadius;
    
    [SerializeField, Tooltip("Attack Distance")]
    protected float _attackDistance;

    [SerializeField, Tooltip("Layer mask for attackable objects")]
    protected LayerMask _attackMask;

    // referance to the player controller
    protected PlayerController _playerController;


    /// <summary>
    /// fire a cast and check if it hit the enemy
    /// and if so Reduce it damage
    /// </summary>
    public virtual void Attack()
    {
        // calculate the attack direction in relation to the mouse position
        Vector2 attackDirection = _inputTracker.mouseWorldPosition - transform.position;
        attackDirection = attackDirection.normalized;

        // see if the attack vector.x to the right or left of the player
        // flip the sprite to the cursor direction when the player is attacking
        _playerController.FlipTheSprite((attackDirection.x < 0) ? true : false);

        // play the animation
        // play the sound

        RaycastHit2D hit = Physics2D.CapsuleCast(transform.position, AttackRadius, CapsuleDirection2D.Horizontal, 0.0f, 
            attackDirection, AttackDistance, _attackMask);
        
        if (hit.collider != null)
        {
            hit.collider.TryGetComponent(out IDamagable damagable);
            Debug.Log($"Attacked {hit.collider.name} for {Damage} damage.");
            damagable.TakeDamage(Damage);
        }
        else
        {
            Debug.Log("Attacked nothing");
        }
    }


    /// <summary>
    /// The Character damage
    /// </summary>
    public float Damage { get => _damage; }
    /// <summary>
    /// The Character attack radius
    /// </summary>
    public Vector2 AttackRadius { get => _attackRadius;}
    /// <summary>
    /// The Character attack distance
    /// </summary>
    public float AttackDistance { get => _attackDistance; }
}
