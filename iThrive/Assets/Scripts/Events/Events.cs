using Assets.Scripts.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Events
{
    public static class Events
    {
        public static TimeBasedEvent ConnieAtNine = new TimeBasedEvent
        {
            StartTime = DateTime.Parse("9:00 AM"),
            Event = () =>
            {
                var dialogue = new Dialogue
                {
                    theirText = "Hey you!",
                    reply1 = "Yo, you hear anything from #####? He hasn't been answering me.",
                    option1 = new Dialogue
                    {
                        theirText = "Not a peep. He can be lame like that, tho.",
                        reply1 = "Ugh, always dissin my dudes Con. He's nice, admit it :wink:",
                        option1 = new Dialogue
                        {
                            theirText = "He was my cuz before he was your dude, dude. But yeah. He's not the worst.",
                            reply1 = "No way! Am I seeing the infamous Con totally fold on a compliment???",
                            option1 = new Dialogue
                            {
                                theirText = "Breathe a word and yer dead.",
                                reply1 = "Copied, pasted, all over on FaceSpace :0",
                                option1 = new Dialogue
                                {
                                    theirText = "My revenge will be swift and merciless. With a side of fries.",
                                    reply1 = "Just kid, haha, wouldn't do that to you",
                                    option1 = new Dialogue
                                    {
                                        theirText = "Obvi. You're way too nice.",
                                        reply1 = "Well, now you make me sound weak. I'm a strong independent couch potato, who need no sportos",
                                        option1 = new Dialogue
                                        {
                                            theirText = "Pssh. If it wasn't for me, you'd never leave the house. Speaking of... You. Me. Coffee today at Frapptabulous. You're so in, right.",
                                            reply1 = "Uhhh, duh, why'd even ask?",
                                            reply2 = "Naw, I need to track down the boy, he's worrying me",
                                            option1 = new Dialogue
                                            {
                                                theirText = "You'll note... it wasn't a question. :stuck_out_tongue_closed_eyes:"
                                            },
                                            option2 = new Dialogue
                                            {
                                                theirText = "Ugh, lame. He's been worrying me for fifteen years."
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                DialogueManager.Instance.SetDialog(dialogue, "Connie");
            }
        };

        public static TimeBasedEvent FrankAtOne = new TimeBasedEvent
        {
            StartTime = DateTime.Parse("1:30 AM"),
            Event = () =>
            {
                var dialogue = new Dialogue
                {
                    theirText = "",
                    reply1 = "Hey!",
                    option1 = new Dialogue
                    {
                        theirText = "Hey! Just saw your message. What's up?",
                        reply1 = "hey have you seen #####??? were supposed to have a date tonight",
                        option1 = new Dialogue
                        {
                            theirText = "Nah. I've been at the library doing homework all day.",
                            reply1 = "",
                            option1 = new Dialogue
                            {
                                theirText = "And you know how #### feels about homework.",
                                reply1 = "ugggh yeah getting him to write an essay last year was a nightmare",
                                option1 = new Dialogue
                                {
                                    theirText = "I can believe it. Ugh. Hang on a sec.",
                                    reply1 = "",
                                    option1 = new Dialogue
                                    {
                                        theirText = "Sorry. Had to talk to some groupmates about an assignment. You wouldn't believe how much work they're giving us in these honors classes.",
                                        reply1 = "",
                                        option1 = new Dialogue
                                        {
                                            theirText = "Where were we?",
                                            reply1 = "so i know you tutored for ##### last summer. you seen him since?",

                                            option1 = new Dialogue
                                            {
                                                theirText = "I haven't talked to Ghost in a while, he hasn't been around as much.",
                                                reply1 = "he hasnt been around much? what you mean? isnt he ur friend?",
                                                option1 = new Dialogue
                                                {
                                                    theirText = "I mean yeah, but isn't he YOUR boyfriend?",
                                                    reply1 = "wow okay sorry mr smartypants",
                                                    option1 = new Dialogue
                                                    {
                                                        theirText = "And we get along. It's not like we're super close or anything.",
                                                        reply1 = "",
                                                        option1 = new Dialogue
                                                        {
                                                            theirText = "He's probably tried to hang out and I've just been too busy to notice.",
                                                            reply1 = "",
                                                            option1 = new Dialogue
                                                            {
                                                                theirText = "Is something wrong with Ghost? You seem worried about him.",
                                                                reply1 = "thats what im talking to you about?",
                                                                option1 = new Dialogue
                                                                {
                                                                    theirText = "You didn't make that super clear to be fair.",
                                                                    reply1 = "frank. help me.",
                                                                    option1 = new Dialogue
                                                                    {
                                                                        theirText = "Okay, okay. SUPPORTIVE-FRIEND-MODE: ACTIVATE.",
                                                                        reply1 = "...",
                                                                        option1 = new Dialogue
                                                                        {
                                                                            theirText = "So, you haven't heard from him. He's been flakey before, hasn't he?",
                                                                            reply1 = "yeah but this is different. i kept calling and messaging but he hasnt answered me",
                                                                            option1 = new Dialogue
                                                                            {
                                                                                theirText = "Did you wait for him to reply back?",
                                                                                reply1 = "haha yeah i did. :/ dude, it's been two weeks... hed tell me if he was gone that long",
                                                                                option1 = new Dialogue
                                                                                {
                                                                                    theirText = "Did you guys have a fight?",
                                                                                    reply1 = "well when summer started, yeah. but that was months ago, i dont think hed be mad about that",
                                                                                    option1 = new Dialogue
                                                                                    {
                                                                                        theirText = "Maybe he's still mad about it and he didn't tell you?",
                                                                                        reply1 = "i mean... maybe? it was my fault, but i didnt think hed still be mad about it",
                                                                                        option1 = new Dialogue
                                                                                        {
                                                                                            theirText = "Did he bring it up?",
                                                                                            reply1 = "no",
                                                                                            option1 = new Dialogue
                                                                                            {
                                                                                                theirText = "I mean, maybe he was still mad and doesnt want to talk to you.",
                                                                                                reply1 = "u think?",
                                                                                                option1 = new Dialogue
                                                                                                {
                                                                                                    theirText = "I don't know. Have you talked to him?",
                                                                                                    reply1 = "well i sent a message...",
                                                                                                    option1 = new Dialogue
                                                                                                    {
                                                                                                        theirText = "Hey, I'm sorry but I gotta go. I hope you figure it out with #####.",
                                                                                                        reply1 = "",
                                                                                                        option1 = new Dialogue
                                                                                                        {
                                                                                                            theirText = "Maybe try reaching out again? Can't hurt.",
                                                                                                            reply1 = "okay... thanks Frankie...",

                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            },

                                            reply2 = "you seem pretty busy. is everything ok?",

                                            option2 = new Dialogue
                                            {
                                                theirText = "Yeah, I've been deep in these honors classes. I'm having some trouble.",
                                                reply1 = "frankie in trouble with school?? huh??",
                                                option1 = new Dialogue
                                                {
                                                    theirText = "I know, crazy.",
                                                    reply1 = "that explains why i didnt see you much last week though. have you been hiding out in the library?",
                                                    option1 = new Dialogue
                                                    {
                                                        theirText = "Yeah, I was stuck on my calculus homework. On top of that I have a part-time job at McBurgie's and my little sister needs babysitting.",
                                                        reply1 = "",
                                                        option1 = new Dialogue
                                                        {
                                                            theirText = "I can't focus at home and take care of her at the same time, you know?",
                                                            reply1 = "",
                                                            option1 = new Dialogue
                                                            {
                                                                theirText = "And this monday I have a big exam, but my parents are going out for dinner.",
                                                                reply1 = "",
                                                                option1 = new Dialogue
                                                                {
                                                                    theirText = "im sorry dude, i wish there was something i could do to help",
                                                                    reply1 = "",
                                                                    option1 = new Dialogue
                                                                    {

                                                                    }
                                                                },

                                                                reply2 = "",
                                                                option2 = new Dialogue //Requires minEnergy 60, +Energy option, +frankflag
                                                                {
                                                                    theirText = "It's what it is, I guess.",
                                                                    reply1 = "",
                                                                    option1 = new Dialogue
                                                                    {
                                                                        theirText = "I just hope I don't fail.",
                                                                        reply1 = "well im gonna go track down #####, ill catch you later. good luck!",
                                                                        option1 = new Dialogue
                                                                        {
                                                                            theirText = "Thanks, I need it..."
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                DialogueManager.Instance.SetDialog(dialogue, "Frankie");
            }
        };
    }
}
