using System;
using System.Linq;
using UnityEngine.UI;

public class Clock : Window {

    public static readonly string WindowName = "ClockWindow";
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
                this.closeButton = this.GetComponentInChildren<Button>();
                this.IsCurrentWindow = true;

                this.closeButton.onClick.AddListener(() => this.TemporaryClose());
            };
        }
    }

    protected override Action OnUpdate
    {
        get
        {
            return () =>
            {
                this.clockText.text = DateTime.Now.ToLongTimeString();
            };
        }
    }

    void TemporaryClose()
    {
        this.Toggle();
    }
}
