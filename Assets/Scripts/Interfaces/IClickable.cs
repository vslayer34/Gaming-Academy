using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    bool IsMarked { get; set; }

    void MarkMe();
    void DeMarkMe();
}
