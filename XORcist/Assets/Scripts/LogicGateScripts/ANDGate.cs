using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDGate : MonoBehaviour
{
    public bool GetOutput(bool a, bool b) 
    {
        if (a == true && b == true)
        {
            return true;
        }
        else 
        { 
            return false;
        }
    }
}
