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
                currentSentence++;
                // currentSentence = currentSentence + 1;
                // same as currentSentence += 1;

                if(currentSentence >= dialogueSentences.Length)
                {
                    dialogueBox.SetActive(false);
                }

                else
                {
                    dialogueText.text = dialogueSentences[currentSentence];
                }

                
            }

            
        }
    }

    public void ActivateDialogue(string[] newSentencesToUse)
    {
        dialogueSentences = newSentencesToUse;
        currentSentence = 0;
        dialogueText.text = dialogueSentences[currentSentence];
        dialogueBox.SetActive(true);
    }
}
