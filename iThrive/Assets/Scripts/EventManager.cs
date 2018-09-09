using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager Instance;
    private Queue<TimeBasedEvent> EventQueue { get; set; }


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
        this.StartCoroutine(this.EventQueueCheck());
    }

    void InitializeQueue()
    {
        this.EventQueue = new Queue<TimeBasedEvent>();
    }

    IEnumerator EventQueueCheck()
    {
        while (true)
        {
            if (this.EventQueue.Count > 0)
            {
                var timeEvent = this.EventQueue.Dequeue();

                if (Player.GetCurrentGameTime() > timeEvent.StartTime)
                {
                    timeEvent.Event();
                }
                else
                {
                    this.EventQueue.Enqueue(timeEvent);
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void AddNewEvent(string startTime, Action evenctAction)
    {
        this.AddNewEvent(new TimeBasedEvent { StartTime = DateTime.Parse(startTime), Event = evenctAction });
    }

    public void AddNewEvent(DateTime startTime, Action evenctAction)
    {
        this.AddNewEvent(new TimeBasedEvent { StartTime = startTime, Event = evenctAction });
    }

    public void AddNewEvent(TimeBasedEvent timeEvent)
    {
        this.EventQueue.Enqueue(timeEvent);
    }
}
