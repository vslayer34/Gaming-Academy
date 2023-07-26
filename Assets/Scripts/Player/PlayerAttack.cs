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

    public virtual void Attack()
    {
        RaycastHit2D hit = Physics2D.CapsuleCast(transform.position, AttackRadius, CapsuleDirection2D.Horizontal, 0.0f, Vector2.left, AttackDistance, _attackMask);
        if (hit.collider.TryGetComponent(out IDamagable damagable))
        {
            Debug.Log($"Attacked {hit.collider.name} for {Damage} damage.");
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
