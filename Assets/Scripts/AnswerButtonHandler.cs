using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonHandler : MonoBehaviour
{
    public DialogueManager dialogueManager; // Assign this in the Inspector
    public Sentence currentSentence; // This should be the current sentence

    public void OnYesButtonClicked()
    {
        dialogueManager.Answer(true);
    }

    public void OnNoButtonClicked()
    {
        dialogueManager.Answer(false);
    }
}

