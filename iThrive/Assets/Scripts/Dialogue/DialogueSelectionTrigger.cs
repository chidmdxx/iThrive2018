using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelectionTrigger : MonoBehaviour {

    public string character;

    public void SelectCharacter(){
        FindObjectOfType<DialogueManager>().SelectConversation(character);
    }
}
