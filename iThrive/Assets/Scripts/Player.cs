using Assets.Scripts.Definitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static double TimeElapsed { get; set; }
    public static float Energy { get; set; }
    public static Dictionary<string, int> LastInteractions { get; private set; }
    public static GameFlags Flags { get; set; }

    private float timer;

	// Use this for initialization
	void Start ()
    {
        Player.Initialize();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.timer += Time.deltaTime;
        if (this.timer > 1f)
        {
            Player.TimeElapsed += 0.1;
            this.timer = 0f;
        }
    }

    public static void Initialize()
    {
        Player.TimeElapsed = 0f;
        Player.Energy = 100;
        Player.Flags = GameFlags.None;
        Player.LastInteractions = new Dictionary<string, int>();
    }
}
