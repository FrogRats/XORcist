using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : MonoBehaviour
{
    public abstract bool GetOutput(bool a, bool b);
}
