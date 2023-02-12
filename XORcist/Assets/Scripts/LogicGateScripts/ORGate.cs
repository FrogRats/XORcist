using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORGate : Gate
{
    public override bool? GetOutput(bool a, bool b)
    {
        if (a == true || b == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
