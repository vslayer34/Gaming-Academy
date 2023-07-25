using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : Enemy
{
    private float headingDirection;
    private float headingRight = 1;
    private float headingLeft = -1;


    //--------------------------------------------------------------------------------------------


    private void FixedUpdate()
    {
        // 1 & -1 represents 
        headingDirection = isLookingRight ? headingRight : headingLeft;
        Move(headingDirection);
    }
}
