using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueTheirsRecentText;
    public Text dialogueMineOldText;
    public Text dialogueTheirsOldText;
    public Text dialogueMineRecentText;
    public Text option1Text;
    public Text option2Text;
    public Text replyText;
    public Button option1Button;
    public Button option2Button;
    public GameObject conversationMineOld;
    public GameObject conversationMineRecent;
    public GameObject conversationTheirsOld;
    public GameObject conversationTheirsRecent;

    private Dialogue dialogue;
    private Dialogue dialogueGhost;
    private Dialogue dialogueConnie;
    private Dialogue dialogueFrank;
    private string currentCharacter;
    private int nextOption = -1;
    private int ghostCount = 0;

    void Start()
    {
        currentCharacter = "Ghost";
        dialogue = Dialogue.dialogueGhost;

        conversationMineOld.gameObject.SetActive(false);
        conversationMineRecent.gameObject.SetActive(false);
        conversationTheirsOld.gameObject.SetActive(false);
        conversationTheirsRecent.gameObject.SetActive(false);
        dialogueTheirsRecentText.text = dialogue.theirText;
        dialogueMineOldText.text = dialogue.myText;
        option1Text.text = dialogue.reply1;
        option2Text.text = dialogue.reply2;
        replyText.text = "";
    }

    public void DisplayNextSentence()
    {
        SoundManager.Instance.PlaySingleSound("Click");

        // Start Ghost hardcoded stuff
        if (currentCharacter.Equals("Ghost"))
        {
            dialogue = Dialogue.dialogueGhost;
            ghostCount++;
            if (ghostCount > 10){
                conversationMineOld.gameObject.SetActive(true);
                conversationMineRecent.gameObject.SetActive(false);
                conversationTheirsOld.gameObject.SetActive(false);
                conversationTheirsRecent.gameObject.SetActive(true);
                dialogueTheirsRecentText.text = "New phone who dis";
                option1Text.text = "";
                option2Text.text = "";
                replyText.text = "";
                nextOption = -1;
                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
                return;
            }
            else {
                if (ghostCount !=1){
                    conversationMineOld.gameObject.SetActive(true);
                }
                conversationMineRecent.gameObject.SetActive(true);
                conversationTheirsOld.gameObject.SetActive(false);
                conversationTheirsRecent.gameObject.SetActive(false);
                option1Text.text = dialogue.reply1;
                option2Text.text = dialogue.reply2;
                replyText.text = "";
            }

            switch (nextOption)
            {
                case 1:
                    dialogueMineOldText.text = dialogueMineRecentText.text;
                    dialogueMineRecentText.text = dialogue.reply1;
                    dialogue = Dialogue.dialogueGhost;
                    break;
                case 2:
                    dialogueMineOldText.text = dialogueMineRecentText.text;
                    dialogueMineRecentText.text = dialogue.reply2;
                    dialogue = Dialogue.dialogueGhost;
                    break;
                default:
                    return;
            }
            option1Button.gameObject.SetActive(true);
            option2Button.gameObject.SetActive(true);
            nextOption = -1;
            return;
        }

        // End of Ghost hardcoded stuff

        switch (nextOption)
        {
            case 1:
                dialogueMineOldText.text = dialogue.reply1;
                dialogue = dialogue.option1;
                break;
            case 2:
                dialogueMineOldText.text = dialogue.reply2;
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

        dialogueTheirsRecentText.text = dialogue.theirText;
        option1Text.text = dialogue.reply1;
        option2Text.text = dialogue.reply2;
        replyText.text = "";
        conversationMineOld.gameObject.SetActive(true);
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
                replyText.text = dialogue.reply2;
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