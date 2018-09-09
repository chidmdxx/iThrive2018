using Assets.Scripts.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static double TimeElapsed { get; private set; }
    public static double Energy { get; private set; }
    public static Dictionary<string, int> LastInteractions { get; private set; }
    public static GameFlags Flags { get; set; }

    private static double TimeSpeed { get; set; }
    private static readonly DateTime gameStartTime = DateTime.Parse("8:00 AM");
    private static readonly DateTime gameEndTime = DateTime.Parse("11:59 PM");
    private static readonly TimeSpan gameTimespan = gameEndTime.Subtract(gameStartTime);

    private float timer;

	// Use this for initialization
	void Start ()
    {
        Player.Initialize();
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.timer += Time.deltaTime;
        if (this.timer > 1f)
        {
            Player.TimeElapsed += Player.TimeSpeed;
            this.timer = 0f;
        }
    }

    public static void Initialize()
    {
        Player.TimeElapsed = 0;
        Player.SetTimeToNormal();
        Player.Energy = 100;
        Player.Flags = GameFlags.None;
        Player.LastInteractions = new Dictionary<string, int>();
    }

    public static void ModifyEnergy(double modifier)
    {
        Player.Energy += modifier;

        if (Player.Energy > 100)
        {
            Player.Energy = 100;
        }

        if (Player.Energy < 0)
        {
            Player.Energy = 0;
        }
    }

    public static void SetTimeToNormal()
    {
        Player.TimeSpeed = 0.1;
    }

    public static void PauseTime()
    {
        Player.TimeSpeed = 0;
    }

    public static void DoubleSpeed()
    {
        Player.TimeSpeed = 0.2;
    }

    public static DateTime GetCurrentGameTime()
    {
        if (Player.TimeElapsed >= 100)
        {
            return Player.gameEndTime.AddMinutes(1);
        }

        var elapsedTime = TimeSpan.FromTicks(Convert.ToInt64(Player.gameTimespan.Ticks * Player.TimeElapsed / 100));
        return Player.gameStartTime.Add(elapsedTime);
    }
}
