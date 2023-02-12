using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level5Script : MonoBehaviour
{

    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;
    [SerializeField] GameObject CRTMonitor3;
    [SerializeField] GameObject CRTMonitor4;
    [SerializeField] GameObject CRTMonitor5;
    [SerializeField] GameObject CRTMonitor6;
    [SerializeField] GameObject CRTMonitor7;
    [SerializeField] GameObject CRTMonitor8;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;
    [SerializeField] Image pendingLaptop;
    [SerializeField] Image successLaptop;

    private CRTLogicScript CRTScript1;
    private CRTLogicScript CRTScript2;
    private CRTLogicScript CRTScript3;
    private CRTLogicScript CRTScript4;
    private CRTLogicScript CRTScript5;
    private CRTLogicScript CRTScript6;
    private CRTLogicScript CRTScript7;
    private CRTLogicScript CRTScript8;

    private bool inputA = true;
    private bool inputB = true;
    private bool inputC = false;
    private bool inputD = false;
    private bool inputE = true;

    private bool currentStatus;


    // Start is called before the first frame update
    void Start()
    {
        CRTScript1 = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();
        CRTScript3 = CRTMonitor3.GetComponent<CRTLogicScript>();
        CRTScript4 = CRTMonitor4.GetComponent<CRTLogicScript>();
        CRTScript5 = CRTMonitor5.GetComponent<CRTLogicScript>();
        CRTScript6 = CRTMonitor6.GetComponent<CRTLogicScript>();
        CRTScript7 = CRTMonitor6.GetComponent<CRTLogicScript>();
        CRTScript8 = CRTMonitor6.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
        pendingLaptop.gameObject.SetActive(true);
        successLaptop.gameObject.SetActive(false);
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript1.getCurrentGateOutput(inputA, inputB);

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(inputA, currentStatus);

        // NOT Inversion
        currentStatus = !currentStatus;

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(currentStatus, inputC);

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(currentStatus, inputD);

        // Fifth CRT Monitor
        currentStatus = CRTScript5.getCurrentGateOutput(currentStatus, inputD);

        // Sixth CRT Monitor
        currentStatus = CRTScript6.getCurrentGateOutput(currentStatus, inputD);

        // Seventh CRT Monitor
        currentStatus = CRTScript7.getCurrentGateOutput(!currentStatus, inputE);

        // Eigth CRT Monitor
        currentStatus = CRTScript8.getCurrentGateOutput(currentStatus, inputE);

        if (currentStatus)
        {
            pendingLaptop.gameObject.SetActive(false);
            successLaptop.gameObject.SetActive(true);


           
        }
    }
}
