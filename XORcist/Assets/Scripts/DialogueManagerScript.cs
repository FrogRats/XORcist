using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManagerScript : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanelNPC;
    [SerializeField] private GameObject dialoguePanelPlayer;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Button continueButton;
    [SerializeField] private Image NPCImage;
    [SerializeField] private Image NPCImage2;
    [SerializeField] private TextMeshProUGUI NPCName;
    [SerializeField] private TextMeshProUGUI NPCName2;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    [Header("Level UI")]
    [SerializeField] private GameObject LevelObj;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    private bool dialogueIsPlaying;
    private string typewriterText;

    private static DialogueManagerScript instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Dialogue Manager has more than one instance in current scene!");
        }

        instance = this;

        // Add button listener
        continueButton.onClick.AddListener(ContinueStory);
    }

    public static DialogueManagerScript GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanelNPC.SetActive(false);
        dialoguePanelPlayer.SetActive(false);
        LevelObj.SetActive(false);

        // Get the text for all the choices
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choices[index].gameObject.SetActive(false);
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanelNPC.SetActive(true);
        dialoguePanelPlayer.SetActive(true);
        LevelObj.SetActive(false);
        NPCImage.gameObject.SetActive(false);
        NPCImage2.gameObject.SetActive(false);
        NPCName.gameObject.SetActive(false);
        NPCName2.gameObject.SetActive(false);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanelNPC.SetActive(false);
        dialoguePanelPlayer.SetActive(false);
        LevelObj.SetActive(true);
        NPCImage.gameObject.SetActive(false);
        NPCImage2.gameObject.SetActive(false);
        NPCName.gameObject.SetActive(false);
        NPCName2.gameObject.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            StopCoroutine("TypewriterText");
            typewriterText = currentStory.Continue();
            StartCoroutine("TypewriterText");
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Too many choices than UI can support!");
        }

        if (currentChoices.Count > 0)
        {
            continueButton.gameObject.SetActive(false);
        }

        if (currentChoices.Count == 0)
        {
            UpdateStoryVariables();
            continueButton.gameObject.SetActive(true);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].SetActive(true);
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }


    private IEnumerator SelectFirstChoice()
    {
        // Set the first choice
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    private IEnumerator TypewriterText()
    {
        dialogueText.text = "";

        foreach (char c in typewriterText){
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        UpdateStoryVariables();
        ContinueStory();
    }

    private void UpdateStoryVariables()
    {
        currentStory.ObserveVariable("Show_NPC", (variableName, newValue) =>
        {
            if ((bool) newValue) { 
                NPCImage.gameObject.SetActive(true);
                NPCName.gameObject.SetActive(true);
            }
            else { 
                NPCImage.gameObject.SetActive(false);
                NPCName.gameObject.SetActive(false);
            }
        });

        currentStory.ObserveVariable("Show_NPC2", (variableName, newValue) =>
        {
            if ((bool)newValue) { 
                NPCImage2.gameObject.SetActive(true);
                NPCName2.gameObject.SetActive(true);
            }
            else { 
                NPCImage2.gameObject.SetActive(false);
                NPCName2.gameObject.SetActive(false);
            }
        });
    }
}

