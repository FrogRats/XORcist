using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] Image successFlame;

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
        CRTScript3 = CRTMonitor3.GetComponent<CRTLogicScript>();
        CRTScript4 = CRTMonitor4.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript.getCurrentGateOutput(inputA, inputB);
        Debug.Log("Gate 1: " + currentStatus);

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, inputC);
        Debug.Log("Gate 2: " + currentStatus);

        // NOT Inversion
        currentStatus = !currentStatus;
        Debug.Log("Not: " + currentStatus);

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(currentStatus, inputD);
        Debug.Log("Gate 3: " + currentStatus);

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(currentStatus, inputE);
        Debug.Log("Gate 4: " + currentStatus);

        if (currentStatus)
        {
            successFlame.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else {

            Debug.Log("AAA");
        }
    }
}
