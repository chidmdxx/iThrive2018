﻿using System;
using System.Linq;
using UnityEngine.UI;

public class Clock : Window {

    public static readonly string WindowName = "ClockWindow";
    private Text clockText;

    protected override Action OnStart
    {
        get
        {
            return () =>
            {
                var textFields = this.GetComponentsInChildren<Text>();
                this.clockText = textFields.First(field => field.name.Equals("Time"));
                this.IsCurrentWindow = true;
            };
        }
    }

    protected override Action OnUpdate
    {
        get
        {
            return () =>
            {
                this.clockText.text = Player.GetCurrentGameTime().ToString("hh:mm tt");
            };
        }
    }
}
