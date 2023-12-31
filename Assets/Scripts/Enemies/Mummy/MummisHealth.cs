using System;
using UnityEngine;

public class MummisHealth : MonoBehaviour, IDamagable
{
    private Action OnHealthRechedZero;
    
    [Header("Health")]
    [SerializeField, Tooltip("The max health value of the mummie")]
    private float _maxHealth = 100.0f;
   
    private float _currentHealth;



    //----------------------------------------------------------------------

    private void Start()
    {
        // set the current health to the max health at the start of the game
        CurrentHealth = _maxHealth;
        OnHealthRechedZero = Die;
    }

    //----------------------------------------------------------------------

    /// <summary>
    /// Applay damage to the health
    /// </summary>
    /// <param name="damageAmount">amount of damage taken</param>
    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0)
        {
            OnHealthRechedZero?.Invoke();
        }

        CurrentHealth -= damageAmount;
        Debug.Log($"The mummie took {damageAmount} damage points and its current health is: {CurrentHealth}");
    }

    /// <summary>
    /// What happens when the health reach zero
    /// </summary>
    public void Die()
    {
        Debug.Log($"my current health reached {CurrentHealth}, now I'm Dead you monster ");
    }

    //----------------------------------------------------------------------------

    public float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
            else if (value > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
            else if (value < 0)
            {
                _currentHealth = 0;
            }
            else
            {
                _currentHealth = value;
            }
        }
    }
}
