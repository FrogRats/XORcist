using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelTransitionScript : MonoBehaviour
{

    [Header("Additional UI")]
    [SerializeField] Button ritualButton;

    // Start is called before the first frame update
    void Start()
    {
        ritualButton.onClick.AddListener(FinalBossScene);
    }
    private void FinalBossScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}