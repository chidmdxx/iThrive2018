using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Text clockText;

    void Update()
    {
        this.clockText.text = Player.GetCurrentGameTime().ToString("hh:mm tt");
    }
}
