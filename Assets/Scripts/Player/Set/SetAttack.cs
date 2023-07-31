using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAttack : PlayerAttack
{
    private void Start()
    {
        _inputTracker.OnPrimaryAttackPressed = Attack;
        _playerController = GetComponent<PlayerController>();
    }

    public override void Attack()
    {
        base.Attack();

        // Add the animation
    }
}
