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
    [SerializeField] private Image[] Gates;

    [Header("CRT Button")]
    [SerializeField] private Button CRTButton;

    private string currentGate;
    private ORGate ORGateScript;
    private ANDGate ANDGateScript;
    private bool changedGate;

    // Update is called once per frame
    void Awake()
    {
        CRTButton.onClick.AddListener(SwitchCRTScreen);
        changedGate= false;
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
                    currentGate = Gates[0].name;
                }
                else 
                {
                    Gates[i + 1].gameObject.SetActive(true);
                    currentGate = Gates[i + 1].name;
                }

                break;
            }
        }
    }

    public bool getCurrentGateOutput(bool inputA, bool inputB) {

        switch (currentGate) {

            case "ORGate":
                ORGateScript = Gates[1].GetComponent<ORGate>();
                return ORGateScript.GetOutput(inputA, inputB);

            case "ANDGate":
                ANDGateScript = Gates[2].GetComponent<ANDGate>();
                return ANDGateScript.GetOutput(inputA, inputB);

            default: return false;

        }
    }

    public bool getGateButtonStatus() {
        return changedGate;
    }
}
