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
    [SerializeField] GameObject successWindow;
    [SerializeField] Image pendingLaptop;
    [SerializeField] Image successLaptop;

    [Header("Audio Sources")]
    [SerializeField] AudioSource BGMusicIntro;
    [SerializeField] AudioSource BGMusicMain;

    private CRTLogicScript CRTScript1;
    private CRTLogicScript CRTScript2;
    private CRTLogicScript CRTScript3;
    private CRTLogicScript CRTScript4;
    private CRTLogicScript CRTScript5;
    private CRTLogicScript CRTScript6;
    private CRTLogicScript CRTScript7;
    private CRTLogicScript CRTScript8;

    private bool t = true;
    private bool f = true;


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
        CRTScript7 = CRTMonitor7.GetComponent<CRTLogicScript>();
        CRTScript8 = CRTMonitor8.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
        pendingLaptop.gameObject.SetActive(true);
        successLaptop.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!BGMusicMain.isPlaying) 
        {
            if (!BGMusicIntro.isPlaying)
            {
                BGMusicMain.Play();
            }
        }
    }

    private void CRTMonitorLogic()
    {
        // First CRT Monitor
        currentStatus = CRTScript1.getCurrentGateOutput(t, t);
        if (currentStatus is null) return;

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, t);
        if (currentStatus is null) return;

        // NOT Inversion
        currentStatus = !currentStatus;

        // Third CRT Monitor
        currentStatus = CRTScript3.getCurrentGateOutput(currentStatus, f);
        if (currentStatus is null) return;

        // Fourth CRT Monitor
        currentStatus = CRTScript4.getCurrentGateOutput(currentStatus, f);
        if (currentStatus is null) return;

        // Fifth CRT Monitor
        currentStatus = CRTScript5.getCurrentGateOutput(currentStatus, f);
        if (currentStatus is null) return;

        // Sixth CRT Monitor
        currentStatus = CRTScript6.getCurrentGateOutput(currentStatus, f);
        if (currentStatus is null) return;

        // NOT Inversion
        currentStatus = !currentStatus;

        // Seventh CRT Monitor
        currentStatus = CRTScript7.getCurrentGateOutput(currentStatus, t);
        if (currentStatus is null) return;

        // Eigth CRT Monitor
        currentStatus = CRTScript8.getCurrentGateOutput(currentStatus, t);
        if (currentStatus is null) return;

        if ((bool)currentStatus)
        {
            pendingLaptop.gameObject.SetActive(false);
            successLaptop.gameObject.SetActive(true);

            successWindow.SetActive(true);
        }
    }
}
