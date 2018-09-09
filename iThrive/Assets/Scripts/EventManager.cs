using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager Instance;
    private Queue<TimeBasedEvent> TimeEventQueue { get; set; }
    private Queue<FlagBasedEvent> FlagEventQueue { get; set; }


    void Awake () {
        if (EventManager.Instance == null)
        {
            EventManager.Instance = this;
        }

        if (EventManager.Instance != this)
        {
            UnityEngine.Object.Destroy(gameObject);
            return;
        }

        UnityEngine.Object.DontDestroyOnLoad(this.gameObject);

        this.InitializeQueue();
        this.StartCoroutine(this.TimeEventQueueCheck());
        this.StartCoroutine(this.FlagEventQueueCheck());
    }

    void InitializeQueue()
    {
        this.TimeEventQueue = new Queue<TimeBasedEvent>();
        this.FlagEventQueue = new Queue<FlagBasedEvent>();
    }

    IEnumerator TimeEventQueueCheck()
    {
        while (true)
        {
            if (this.TimeEventQueue.Count > 0)
            {
                var timeEvent = this.TimeEventQueue.Dequeue();

                if (Player.GetCurrentGameTime() > timeEvent.StartTime)
                {
                    timeEvent.Event();
                }
                else
                {
                    this.TimeEventQueue.Enqueue(timeEvent);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator FlagEventQueueCheck()
    {
        while (true)
        {
            if (this.FlagEventQueue.Count > 0)
            {
                var flagEvent = this.FlagEventQueue.Dequeue();

                if ((Player.Flags & flagEvent.requiredFlags) != 0)
                {
                    flagEvent.Event();
                }
                else
                {
                    this.FlagEventQueue.Enqueue(flagEvent);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void AddNewTimeEvent(string startTime, Action evenctAction)
    {
        this.AddNewTimeEvent(new TimeBasedEvent { StartTime = DateTime.Parse(startTime), Event = evenctAction });
    }

    public void AddNewTimeEvent(DateTime startTime, Action evenctAction)
    {
        this.AddNewTimeEvent(new TimeBasedEvent { StartTime = startTime, Event = evenctAction });
    }

    public void AddNewTimeEvent(TimeBasedEvent timeEvent)
    {
        this.TimeEventQueue.Enqueue(timeEvent);
    }

    public void AddNewFlagEvent(GameFlags flags, Action eventAction)
    {
        this.FlagEventQueue.Enqueue(new FlagBasedEvent { requiredFlags = flags, Event = eventAction });
    }

    public void AddNewFlagEvent(FlagBasedEvent timeEvent)
    {
        this.FlagEventQueue.Enqueue(timeEvent);
    }
}
