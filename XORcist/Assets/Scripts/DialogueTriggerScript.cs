using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerScript : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool DialogueInstance = false;

    private void Update()
    {
        if (!DialogueInstance)
        {
            DialogueManagerScript.GetInstance().EnterDialogueMode(inkJSON);
            DialogueInstance = true;
        }
    }


}
