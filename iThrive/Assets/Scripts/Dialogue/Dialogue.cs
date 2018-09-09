using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue {

    public string theirText;
    public string myText;
    public string reply1;
    public string reply2;
    public Dialogue option1;
    public Dialogue option2;

    public static Dialogue dialogueGhost = new Dialogue
        {
            theirText = "",
            myText = "",
            reply1 = "I love you!",
            reply2 = "Screw you!",
            option1 = null,
            option2 = null
        };
}
