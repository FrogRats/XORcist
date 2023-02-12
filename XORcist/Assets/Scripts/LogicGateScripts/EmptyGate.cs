using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmptyGate : Gate
{
    public override bool? GetOutput(bool a, bool b)
    {
        return null;
    }
}
