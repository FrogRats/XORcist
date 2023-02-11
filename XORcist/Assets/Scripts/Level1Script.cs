using System.Collections;
using System.Collections.Generic;
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

        // Second CRT Monitor
        currentStatus = CRTScript2.getCurrentGateOutput(currentStatus, inputC);

        // Final NOT Gate
        currentStatus = !currentStatus;

<<<<<<< Updated upstream
        if (currentStatus) {
            successFlame.gameObject.SetActive(true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
=======
        Debug.Log(currentStatus);
>>>>>>> Stashed changes
    }
}
