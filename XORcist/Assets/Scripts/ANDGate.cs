using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANDGate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
