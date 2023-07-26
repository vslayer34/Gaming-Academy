public interface IDamagable
{
    /// <summary>
    /// The object can take damage
    /// </summary>
    /// <param name="damageAmount"></param>
    void TakeDamage(float damageAmount);

    /// <summary>
    /// the object can die :(
    /// </summary>
    void Die();
}
