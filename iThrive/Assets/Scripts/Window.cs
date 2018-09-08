using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour {

    public bool IsCurrentWindow { get; set; }

    protected virtual Action OnStart { get; set; }

    protected virtual Action OnUpdate { get; set; }

	// Use this for initialization
	void Start ()
    {
        this.OnStart();
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
}
