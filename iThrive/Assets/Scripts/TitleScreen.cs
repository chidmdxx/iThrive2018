using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {
        Debug.Log("Transition to play cutscene");
    }
    public void HTP()
    {
        Debug.Log("Move to How To Play/ Tutorials");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Break();
    }
}
