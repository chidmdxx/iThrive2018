using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueTheirsText;
    public Text dialogueMineText;
    public Text option1Text;
    public Text option2Text;
    public Text option3Text;

    private Queue<string> sentenceQueue;

    void Start()
    {
        sentenceQueue = new Queue<string>();
        sentenceQueue.Enqueue("Hola");
        sentenceQueue.Enqueue("K ase");
        sentenceQueue.Enqueue("Wasaaa");
    }

    public void DisplayNextSentence()
    {
        if (sentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string currentSetnence = sentenceQueue.Dequeue();
        dialogueTheirsText.text = currentSetnence;
        dialogueMineText.text = "Howdy!";
        option1Text.text = "Hell yes";
        option2Text.text = "Over my dead body!";
        option3Text.text = "Mebbeh";
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}