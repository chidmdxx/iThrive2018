using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubPolarBear : MonoBehaviour {

    public InternetWindow InternetWindow;
    public float timePlayed;

	// Update is called once per frame
	void Update () {
        if (InternetWindow.IsCurrentWindow) return; //send message to player object -> trigger energy modification based on time played
        timePlayed += Time.deltaTime;
	}
}
