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

    public static Dialogue dialogueConnie = new Dialogue
    {
        theirText = "Hey, want to grab coffee?",
        myText = "",
        reply1 = "Yes",
        reply2 = "No",
        option1 = new Dialogue
        {
            theirText = "Cool!",
            myText = "",
            reply1 = "",
            reply2 = "",
            option1 = null,
            option2 = null
        },
        option2 = new Dialogue
        {
            theirText = "Bummer",
            myText = "",
            reply1 = "",
            reply2 = "",
            option1 = null,
            option2 = null
        }
    };

    public static Dialogue dialogueFrank = new Dialogue
    {
        theirText = "Hey, want to grab tea?",
        myText = "",
        reply1 = "Yes tea",
        reply2 = "No tea",
        option1 = new Dialogue
        {
            theirText = "Cool tea!",
            myText = "",
            reply1 = "",
            reply2 = "",
            option1 = null,
            option2 = null
        },
        option2 = new Dialogue
        {
            theirText = "Bummer tea",
            myText = "",
            reply1 = "",
            reply2 = "",
            option1 = null,
            option2 = null
        }
    };
}
