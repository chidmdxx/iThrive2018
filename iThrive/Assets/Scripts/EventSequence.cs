using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSequence : MonoBehaviour {

    private EventManager eventManager;
    bool connieCoffee;
    bool dogWalk;
    bool frankConvo;
    bool frankHelp;
    Queue<string> q = new Queue<string>();
    // Use this for initialization
    void Start () {
		eventManager = FindObjectOfType<EventManager>();
        eventManager.AddNewTimeEvent(DateTime.Parse("8:15 AM"), Hello);


        //eventManager.AddNewEvent(DateTime.Parse("9:00 AM"), ConnieDialog);



        eventManager.AddNewTimeEvent(DateTime.Parse("8:00 AM"), Beginning);
        eventManager.AddNewTimeEvent(DateTime.Parse("8:00 PM"), Intro); //IRL Bubble
        eventManager.AddNewTimeEvent(DateTime.Parse("10:30 AM"), MomIntro);
        eventManager.AddNewTimeEvent(DateTime.Parse("6:00 PM"), MomDog);

        //eventManager.AddNewEvent(DateTime.Parse("10:45 AM", Connie); use function to check if coffee is true IRL Bubble

        //eventManager.AddNewEvent(DateTime.Parse("4:00 PM", dogwalk); make choice IRL Bubble

        //eventManager.AddNewEvent(DateTime.Parse("6:00 PM", Mom); use function to check if dogwalk was true or false IRL Bubble

    }
    void Hello()
    {
        Debug.Log("Hello");
    }
    void Intro()
    {
        q.Clear();
        q.Enqueue("...he's not coming.");
        q.Enqueue("Where did things go wrong? Why couldn't I be better for him?");
        q.Enqueue("I've been staring at this screen for hours, wondering.");
        q.Enqueue("Ugh, I feel like the chat window is judging me.");
        q.Enqueue("So many damn questions. I just want to give up hope.");
        q.Enqueue("What the hell is that? It looks like a 10 minute effort in paint.");
        q.Enqueue("Another chance? That's oddly topical.");
        q.Enqueue("Should... should I click it?");
        q.Enqueue("Yeah, I'm clicking it.");
        Desktop.Disp(q, true);
    }
    void Beginning()
    {
        q.Clear();
        q.Enqueue("I look at the time. September 8th? That's not right.");
        q.Enqueue("My room looks... different. Did mom come in to clean?");
        q.Enqueue("What if... that pop up? Can that even happen?");
        q.Enqueue("I heard about crazy viruses, but this is something totally different.");
        q.Enqueue("What if... I have the chance to make things right?");
        q.Enqueue("Today was the day he left his last message in IM...");
        q.Enqueue(" maybe this is my chance to make things right.");
        q.Enqueue("I can repair everything before he left me.");
        Desktop.Disp(q, true);
    }
    void MomIntro()
    {
        q.Clear();
        q.Enqueue("Mom: Good morning, Sweetroll!");
        q.Enqueue("Me: Ew, Mom. No.");
        q.Enqueue("Mom: I'm going out to meet Linda for bridge club,");
        q.Enqueue(" I just thought you should know, and I wanted to remind you to");
        q.Enqueue("walk the dog before you go out tonight. Okay, lambchop?");
        q.Enqueue("Me: Ugh, fine. But can you spare me the very obviously terrible");
        q.Enqueue("endearments you assign just to make me puke?");
        q.Enqueue("Mom: Just as soon as you stop making me remind you, my little casserole.");

        Desktop.Disp(q, false);
    }
    void MomDog()
    {
        q.Clear();
        if (dogWalk)
        {
            q.Enqueue("Mom: Hey sugarlump, thanks for taking Grouch Barx out for a walk.");
            q.Enqueue("Me:Ew, sugarlump... what even is that?");
            q.Enqueue("Mom: Those crosswords have been helping with my creativity.");
            q.Enqueue("Me: Stop doing them...");
            q.Enqueue("Mom: ...listen, I noticed you've been spending a lot of time in your room.");
            q.Enqueue("I want to let you know that if you need anything, me and your mama are here for you.");
            q.Enqueue("Me: Okay, thanks mom...");
            q.Enqueue("Mom: Really, if there's anything going on, you can tell me.");
            q.Enqueue("Me: ...");
            q.Enqueue("Mom: I'll let you know when dinner is ready. Love you, babyboo.");
        }
        else
        {
            q.Enqueue("Mom: Hey dear, Groucho Barx is hootin' and hollerin' like he hasn't been outside all day.");
            q.Enqueue("Me(Thinking): Oh, I didn't walk the dog...");
            q.Enqueue("Sorry mom, I forgot...");
            q.Enqueue("I've been hearing that a lot. Your mama came home yesterday and had to take the garbage out herself. ");
            q.Enqueue("She had been working hard all week while you've been at your computer.");
            q.Enqueue("This isn't hard, dear. You've had all summer to relax, but now you need to help out.");
            q.Enqueue("Me(Thinking): I think I hate when she calls me dear more than the nicknames...");
            q.Enqueue("Mom: What do you have to say for yourself? You want me to clean your room too? It's a mess.");
            q.Enqueue("Me: It's organized chaos. If you clean it, I'll lose my stuff.");
            q.Enqueue("You know you're always telling me to be more organized. Don't judge, super rude.");
            q.Enqueue("Mom: I'm not in the mood for your attitude. You haven't been doing what I tell you...");
            q.Enqueue("Me: I've been doing what I'm told all my life! Maybe you could listen and leave me alone.");
            q.Enqueue("Mom: You're living in this house, you need to contribute to it!");
            q.Enqueue("Me(Thinking): She's not going to get it. She never does.");
            q.Enqueue("Me(Thinking): She's always yelling at me and calling me stupid names...");

            if (!connieCoffee)
                q.Enqueue("Connie's being more of an arrogant jerk than usual...");
            if (!frankHelp)
                q.Enqueue("Frank doesn't know where ##### is...");

        }

        Desktop.Disp(q, false);
    }


    void Ending()
    {
        if (!(connieCoffee && frankHelp && dogWalk) && Player.Energy > 49)
        {

        }
        else
        {

        }
    }
    void MomSpeech()
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
}
