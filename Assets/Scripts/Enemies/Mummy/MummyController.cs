using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : Enemy, IClickable
{
    private float headingDirection;
    private float headingRight = 1;
    private float headingLeft = -1;


    //--------------------------------------------------------------------------------------------


    private void FixedUpdate()
    {
        // 1 (left) & -1 (right) represents direction
        headingDirection = isLookingRight ? headingRight : headingLeft;
        Move(headingDirection);
    }

    //----------------------------------------------------------------------------------------------------

    public void MarkMe()
    {
        Debug.Log("I'm currently marked");
    }

    public void DeMarkMe()
    {
        Debug.Log("I'm now free from your marking");
    }

    //-------------------------------------------------------------------------------------------------

    public bool IsMarked { get; set; }
}
