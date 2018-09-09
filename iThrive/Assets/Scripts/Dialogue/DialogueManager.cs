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
    private Dialogue dialogueGhost;
    private Dialogue dialogueConnie;
    private Dialogue dialogueFrank;
    private string currentCharacter;
    private int nextOption = -1;

    void Start()
    {
        currentCharacter = "Ghost";
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
        SoundManager.Instance.PlaySingleSound("Click");
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
        SoundManager.Instance.PlaySingleSound("Click");
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

    public void SelectConversation(string character){
        switch (currentCharacter)
        {
            case "Ghost":
                dialogueGhost = dialogue;
                break;
            case "Connie":
                dialogueConnie = dialogue;
                break;
            case "Frank":
                dialogueFrank = dialogue;
                break;
        }

        switch (character)
        {
            case "Ghost":
                dialogue = dialogueGhost;
                break;
            case "Connie":
                dialogue = dialogueConnie;
                break;
            case "Frank":
                dialogue = dialogueFrank;
                break;
        }

        currentCharacter = character;
        Debug.Log("Current character is " + character);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}