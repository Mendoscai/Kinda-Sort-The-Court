using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public NpcController npcController;
    public StatManager statManager;

    public Text nameText;
    public Image avatarImage;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject answerBox;

    private Sentence currentSentence;

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        answerBox.SetActive(true);

        nameText.text = dialogue.name;
        avatarImage.sprite = dialogue.avatar;

        currentSentence = dialogue.sentences[Random.Range(0, dialogue.sentences.Count)];
        dialogueText.text = currentSentence.text;

        // Add these lines to print the number of consequences
        Debug.Log("Number of yes consequences: " + currentSentence.yesConsequences.Count);
        Debug.Log("Number of no consequences: " + currentSentence.noConsequences.Count);
    }



    public void Answer(bool yes)
    {
        Debug.Log("Answer called");
        List<Consequence> consequences = yes ? currentSentence.yesConsequences : currentSentence.noConsequences;
        Debug.Log("Number of consequences: " + consequences.Count);
        foreach (Consequence consequence in consequences)
        {
            Debug.Log("loopexecuted");
            Stat stat = statManager.stats.Find(s => s.name == consequence.statName);

            if (stat != null)
            {
                stat.value += consequence.value;
                if (stat.value <= 0 || stat.value >= 100)
                {
                    // Store the current scene index
                    PlayerPrefs.SetInt("GameOverScene", SceneManager.GetActiveScene().buildIndex);

                    // Load the GameOver scene
                    SceneManager.LoadScene("GameOverScene");
                }

                else
                {
                    statManager.UpdateCircle(stat); // Update the circle after changing the value
                }
            }
        }
    }



    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        answerBox.SetActive(false);

        npcController.ReturnNPC();
    }
}

