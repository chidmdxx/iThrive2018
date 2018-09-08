using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour {

    public bool IsCurrentWindow { get; set; }

    protected abstract Action OnStart { get; set; }

    protected abstract Action OnUpdate { get; set; }

	// Use this for initialization
	void Start ()
    {
        this.OnStart();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (IsCurrentWindow)
        {
            this.OnUpdate();
        }
	}

    void Select()
    {
        this.IsCurrentWindow = true;
    }

    void UnSelect()
    {
        this.IsCurrentWindow = false;
    }

    void Toggle()
    {
        this.IsCurrentWindow = !this.IsCurrentWindow;
    }
}
