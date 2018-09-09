using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueTheirsText;
    public Text dialogueMineText;
    public Text option1Text;
    public Text option2Text;
    public Text replyText;
    public Button option1Button;
    public Button option2Button;
    public GameObject conversationMine;

    private Dialogue dialogue;
    private int nextOption = -1;

    void Start()
    {
        dialogue = new Dialogue
        {
            theirText = "Want some coffee?",
            myText = "",
            reply1 = "Yeah",
            reply2 = "Nah",
            option1 = new Dialogue
            {
                theirText = "Yay!",
                myText = "",
                reply1 = "",
                reply2 = ""
            },
            option2 = new Dialogue
            {
                theirText = "Bummer!",
                myText = "",
                reply1 = "",
                reply2 = ""
            }
        };

        conversationMine.gameObject.SetActive(false);
        dialogueTheirsText.text = dialogue.theirText;
        dialogueMineText.text = dialogue.myText;
        option1Text.text = dialogue.reply1;
        option2Text.text = dialogue.reply2;
        replyText.text = "";
    }

    public void DisplayNextSentence()
    {
        switch (nextOption)
        {
            case 1:
                dialogueMineText.text = dialogue.reply1;
                dialogue = dialogue.option1;
                break;
            case 2:
                dialogueMineText.text = dialogue.reply2;
                dialogue = dialogue.option2;
                break;
            default:
                return;
        }

        if (dialogue == null)
        {
            EndDialogue();
            return;
        }

        dialogueTheirsText.text = dialogue.theirText;
        option1Text.text = dialogue.reply1;
        option2Text.text = dialogue.reply2;
        replyText.text = "";
        conversationMine.gameObject.SetActive(true);
        nextOption = -1;
    }

    public void SelectNextOption(int option){
        nextOption = option;
        option1Button.gameObject.SetActive(false);
        option2Button.gameObject.SetActive(false);
        switch (nextOption)
        {
            case 1:
                replyText.text = dialogue.reply1;
                break;
            case 2:
                replyText.text = dialogue.reply1;
                break;
        }
        Debug.Log("Next option is " + option);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}