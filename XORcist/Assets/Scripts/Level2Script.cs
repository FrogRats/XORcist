using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Script : MonoBehaviour
{

    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;
    [SerializeField] GameObject CRTMonitor3;
    [SerializeField] GameObject CRTMonitor4;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;

    private CRTLogicScript CRTScript;
    private CRTLogicScript CRTScript2;
    private CRTLogicScript CRTScript3;
    private CRTLogicScript CRTScript4;

    private bool inputA = true;
    private bool inputB = true;
    private bool inputC = false;
    private bool inputD = true;
    private bool inputE = false;

    private bool currentStatus;


    // Start is called before the first frame update
    void Start()
    {
        CRTScript = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();
        CRTScript3 = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript4 = CRTMonitor2.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript.getCurrentGateOutput(inputA, inputB);

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, inputC);

        // NOT Inversion
        currentStatus = !currentStatus;

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(currentStatus, inputD);

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(currentStatus, inputE);

        Debug.Log(currentStatus);
    }
}