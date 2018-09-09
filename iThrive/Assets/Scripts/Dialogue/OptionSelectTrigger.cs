using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelectTrigger : MonoBehaviour {

    public int option;

    public void SelectOption(){
        FindObjectOfType<DialogueManager>().SelectNextOption(option);
    }
}
