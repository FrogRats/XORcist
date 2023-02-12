using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level1Script : MonoBehaviour
{
    [Header("CRT Monitors")]
    [SerializeField] GameObject CRTMonitor1;
    [SerializeField] GameObject CRTMonitor2;

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;
    [SerializeField] Image successFlame;

    private CRTLogicScript CRTScript;
    private CRTLogicScript CRTScript2;

    private bool t = true;
    private bool f = false;

    private bool? currentStatus;

    // Start is called before the first frame update
    void Start()
    {
        CRTScript = CRTMonitor1.GetComponent<CRTLogicScript>();
        CRTScript2 = CRTMonitor2.GetComponent<CRTLogicScript>();

        ritualButton.onClick.AddListener(CRTMonitorLogic);
    }

    private void CRTMonitorLogic() {



        // First CRT Monitor
        currentStatus = CRTScript.getCurrentGateOutput(t, f);
        if (currentStatus is null) return;

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, f);
        if (currentStatus is null) return;

        // Final NOT Gate
        currentStatus = !currentStatus;

        if ((bool)currentStatus) {
            successFlame.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
