using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager Instance;
    private Queue<TimeBasedEvent> TimeEventQueue { get; set; }


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
    }

    void InitializeQueue()
    {
        this.TimeEventQueue = new Queue<TimeBasedEvent>();
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
}
