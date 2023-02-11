using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGate : Gate
{
    public override bool GetOutput(bool a, bool b)
    {
        return false;
    }
}
