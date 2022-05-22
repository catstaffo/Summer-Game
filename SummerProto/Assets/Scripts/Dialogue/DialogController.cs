using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;

    [SerializeField] TextMeshProUGUI dialogueText, nameText;
    [SerializeField] GameObject dialogueBox, nameBox;

    [SerializeField] string[] dialogueSentences;
    [SerializeField] int currentSentence;

    private bool dialogueJustStarted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogueText.text = dialogueSentences[currentSentence];
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueBox.activeInHierarchy)
        {
            if(Input.GetButtonUp("Fire1"))
            {

                if(!dialogueJustStarted)
                {   
                    currentSentence++;
                // currentSentence = currentSentence + 1;
                // same as currentSentence += 1;
                

                

                if(currentSentence >= dialogueSentences.Length)
                {   
                    dialogueBox.SetActive(false);
                    PlayerController.instance.deactivatedMovement = false;
                }

                else
                {   CheckForName();
                    dialogueText.text = dialogueSentences[currentSentence];
                }
                }

                else
                {
                    dialogueJustStarted = false;
                }
                
            }

            
        }
    }

    public void ActivateDialogue(string[] newSentencesToUse)
    {
        dialogueSentences = newSentencesToUse;
        currentSentence = 0;
        CheckForName();
        dialogueText.text = dialogueSentences[currentSentence];
        dialogueBox.SetActive(true);

        dialogueJustStarted = true;
        PlayerController.instance.deactivatedMovement = true;
    }

    void CheckForName()
    {
        if(dialogueSentences[currentSentence].StartsWith("#"))
        {
            nameText.text = dialogueSentences[currentSentence].Replace("#", "");
            currentSentence++;
        }
    }

    public bool IsDialogueBoxActive()
    {
        return dialogueBox.activeInHierarchy;
    }
}
