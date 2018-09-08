using System;
using System.Linq;
using UnityEngine.UI;

public class Clock : Window {

    public static readonly string WindowName = "ClockWindow";

    private static readonly DateTime gameStartTime = DateTime.Parse("8:00 AM");
    private static readonly DateTime gameEndTime = DateTime.Parse("11:59 PM");
    private static readonly TimeSpan gameTimespan = gameEndTime.Subtract(gameStartTime);
    private Text clockText;
    private Button closeButton;

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
                this.clockText.text = this.GetCurrentGameTime();
            };
        }
    }

    private string GetCurrentGameTime()
    {
        if (Player.TimeElapsed >= 100)
        {
            return Clock.gameEndTime.AddMinutes(1).ToString("hh:mm tt");
        }

        var elapsedTime = TimeSpan.FromTicks(Convert.ToInt64(Clock.gameTimespan.Ticks * Player.TimeElapsed / 100));
        return Clock.gameStartTime.Add(elapsedTime).ToString("hh:mm tt");
    }
}
