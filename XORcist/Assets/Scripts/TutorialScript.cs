using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [Header("Additional UI")]
    [SerializeField] Button closeTutorial;
    [SerializeField] GameObject tutorialWindow;


    // Start is called before the first frame update
    void Start()
    {
        closeTutorial.onClick.AddListener(closeTutorialWindow);
    }

    private void closeTutorialWindow() { 
        tutorialWindow.SetActive(false);
    }
}
