using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    public bool IsMarked { get; set; }

    public void MarkMe();
    public void DeMarkMe();
}
