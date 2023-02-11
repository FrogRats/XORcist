using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

public class CRTLogicScript : MonoBehaviour
{

    [Header("Gate Options")]
    [SerializeField] private Gate[] Gates;

    [Header("CRT Button")]
    [SerializeField] private Button CRTButton;

    private string currentGateName;
    private Gate currentGate;

    // Update is called once per frame
    void Awake()
    {
        CRTButton.onClick.AddListener(SwitchCRTScreen);
    }

    private void SwitchCRTScreen()
    {

        for (int i = 0; i < Gates.Length; i++)
        {
            if (Gates[i].IsActive())
            {
                Gates[i].gameObject.SetActive(false);

                if (i == Gates.Length - 1)
                {
                    Gates[0].gameObject.SetActive(true);
                    currentGateName = Gates[0].name;
                    currentGate = Gates[0];
                }
                else 
                {
                    Gates[i + 1].gameObject.SetActive(true);
                    currentGateName = Gates[i + 1].name;
                    currentGate = Gates[i + 1];
                }

                break;
            }
        }
    }

    public bool getCurrentGateOutput(bool inputA, bool inputB) {

        return currentGate.GetOutput(inputA, inputB);

    }
}
