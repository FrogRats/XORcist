using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogueTrigger : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool DialogueInstance = false;

    private void Update()
    {
        if (!DialogueInstance)
        {
            IntroDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            DialogueInstance = true;
        }
    }


}

