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
    //[SerializeField] private Image NPCImage;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    [Header("Timer UI")]
    [SerializeField] private TextMeshProUGUI timerText;

    [Header("Inventory UI")]
    [SerializeField] private TextMeshProUGUI tempUIItem1;
    [SerializeField] private TextMeshProUGUI tempUIItem2;

    private TextMeshProUGUI[] choicesText;

    private List<string> tags;
    private Story currentStory;
    private bool dialogueIsPlaying;
    private string typewriterText;
    private bool currentlyTyping;

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
        //NPCImage.gameObject.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanelNPC.SetActive(false);
        dialoguePanelPlayer.SetActive(false);
        //NPCImage.gameObject.SetActive(false);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        currentlyTyping = true;

        foreach (char c in typewriterText){
            dialogueText.text += c;
            yield return new WaitForSeconds(0.02f);
        }

        currentlyTyping = false;
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        UpdateStoryVariables();
        ContinueStory();
    }

    private void UpdateStoryVariables()
    {
        /*
        currentStory.ObserveVariable("Variable_Name_Here", (variableName, newValue) =>
        {
            tempUIItem1.text = newValue.ToString();
            tempUIItem1.fontSize = 14;
        });*/
    }
}

