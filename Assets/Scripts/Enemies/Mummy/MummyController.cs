using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : Enemy, IClickable
{
    private float headingDirection;
    private float headingRight = 1;
    private float headingLeft = -1;

    public bool IsMarked { get; set; }

    public void MarkMe()
    {
        Debug.Log("I'm currently marked");
    }


    //--------------------------------------------------------------------------------------------


    private void FixedUpdate()
    {
        // 1 & -1 represents 
        headingDirection = isLookingRight ? headingRight : headingLeft;
        Move(headingDirection);
    }
}
