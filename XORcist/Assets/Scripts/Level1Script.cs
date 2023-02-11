using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Script : MonoBehaviour
{
    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;

    private CRTLogicScript CRTScript;
    private CRTLogicScript CRTScript2;

    private bool inputA = true;
    private bool inputB = false;
    private bool inputC = false;

    private bool currentStatus;

    // Start is called before the first frame update
    void Start()
    {
        CRTScript = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic() {
        // First CRT Monitor
        currentStatus = CRTScript.getCurrentGateOutput(inputA, inputB);
        Debug.Log("First Monitor: " + currentStatus);

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, inputC);
        Debug.Log("Second Monitor: " + currentStatus);

        // Final NOT Gate
        Debug.Log(!currentStatus);
    }
}
