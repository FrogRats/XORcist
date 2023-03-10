using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level3Script : MonoBehaviour
{

    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;
    [SerializeField] GameObject CRTMonitor3;
    [SerializeField] GameObject CRTMonitor4;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;
    [SerializeField] Image successFlame;

    private CRTLogicScript CRTScript;
    private CRTLogicScript CRTScript2;
    private CRTLogicScript CRTScript3;
    private CRTLogicScript CRTScript4;

    private bool inputA = true;
    private bool inputB = true;
    private bool inputC = true;
    private bool inputD = true;
    private bool inputE = true;

    private bool? currentStatus;


    // Start is called before the first frame update
    void Start()
    {
        CRTScript = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();
        CRTScript3 = CRTMonitor3.GetComponent<CRTLogicScript>();
        CRTScript4 = CRTMonitor4.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript.getCurrentGateOutput(inputA, inputB);
        if (currentStatus is null) return;

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, inputC);
        if (currentStatus is null) return;

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(currentStatus, inputD);
        if (currentStatus is null) return;

        // NOT Inversion
        currentStatus = !currentStatus;

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(currentStatus, inputE);
        if (currentStatus is null) return;

        // NOT Inversion
        currentStatus = !currentStatus;

        if ((bool)currentStatus)
        {
            successFlame.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
