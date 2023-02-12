using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4Script : MonoBehaviour
{

    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;
    [SerializeField] GameObject CRTMonitor3;
    [SerializeField] GameObject CRTMonitor4;
    [SerializeField] GameObject CRTMonitor5;
    [SerializeField] GameObject CRTMonitor6;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;
    [SerializeField] Image successFlame;

    private CRTLogicScript CRTScript1;
    private CRTLogicScript CRTScript2;
    private CRTLogicScript CRTScript3;
    private CRTLogicScript CRTScript4;
    private CRTLogicScript CRTScript5;
    private CRTLogicScript CRTScript6;

    private bool inputA = true;
    private bool inputB = true;
    private bool inputC = true;
    private bool inputD = true;

    private bool? currentStatus;


    // Start is called before the first frame update
    void Start()
    {
        CRTScript1 = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();
        CRTScript3 = CRTMonitor3.GetComponent<CRTLogicScript>();
        CRTScript4 = CRTMonitor4.GetComponent<CRTLogicScript>();
        CRTScript5 = CRTMonitor5.GetComponent<CRTLogicScript>();
        CRTScript6 = CRTMonitor6.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript1.getCurrentGateOutput(inputA, inputB);
        if (currentStatus is null) return;

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(inputC, currentStatus);
        if (currentStatus is null) return;

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(inputD, !currentStatus);
        if (currentStatus is null) return;

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(inputD, currentStatus);
        if (currentStatus is null) return;

        // Fifth CRT Monitor
        currentStatus = CRTScript5.getCurrentGateOutput(inputD, currentStatus);
        if (currentStatus is null) return;

        // Sixth CRT Monitor
        currentStatus = CRTScript6.getCurrentGateOutput(inputD, currentStatus);
        if (currentStatus is null) return;

        if ((bool)currentStatus)
        {
            successFlame.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
