using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XNORGate : Gate
{
    public override bool? GetOutput(bool a, bool b)
    {
        if (!(a == true && b == true) && (a == true) || (b == true))
        {
            return false;
        }
        else
        {
            return true;

        }
    }
}
