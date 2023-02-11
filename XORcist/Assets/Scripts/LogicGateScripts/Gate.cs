using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    public Gate() 
    { 
    
    }

    public bool IsActive() 
    {
        return isActiveAndEnabled;
    }

    public abstract bool GetOutput(bool a, bool b);
}
