using System;
using System.Linq;
using UnityEngine.UI;

public class IM : Window {

    public static readonly string WindowName = "IMWindow";

    private Button closeButton;

    protected override Action OnStart
    {
        get
        {
            return () =>
            {
                var textFields = this.GetComponentsInChildren<Text>();
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
            };
        }
    }
}
