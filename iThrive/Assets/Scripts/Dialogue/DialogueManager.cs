using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;

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

        dialogueText.text = sentenceQueue.Dequeue();
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}