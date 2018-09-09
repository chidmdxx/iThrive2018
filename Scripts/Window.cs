using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour {

    public bool IsCurrentWindow { get; set; }
    public Button CloseButton { get; set; }
    protected virtual Action OnStart { get; set; }
    protected virtual Action OnUpdate { get; set; }

	// Use this for initialization
	void Start ()
    {
        this.OnStart();
        var buttons = this.GetComponentsInChildren<Button>();
        print(buttons.Length);
        this.CloseButton = buttons.First(field => field.name.Equals("CloseButton"));
        this.CloseButton.onClick.AddListener(Close);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (this.IsCurrentWindow)
        {
            this.OnUpdate();
        }
	}

    public void Select()
    {
        this.IsCurrentWindow = true;
    }

    public void UnSelect()
    {
        this.IsCurrentWindow = false;
    }

    public void Toggle()
    {
        this.IsCurrentWindow = !this.IsCurrentWindow;
    }

    public void Close()
    {
        UnityEngine.Object.Destroy(this.gameObject);
    }
}
