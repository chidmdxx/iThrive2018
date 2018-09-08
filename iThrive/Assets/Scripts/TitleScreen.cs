using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public GameObject titleUI;
    public GameObject playUI;
    public Image blackScreen;

	// Use this for initialization
	void Start () {

        blackScreen.canvasRenderer.SetAlpha(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {
        Debug.Log("Transition to play cutscene");
        titleUI.SetActive(false);
        StartCoroutine(fade(playUI));
        //playUI.SetActive(true);
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
    IEnumerator fade(GameObject sceneUI)
    {
        blackScreen.CrossFadeAlpha(1f, 2f, true);      
        yield return new WaitForSeconds(2f);
        blackScreen.CrossFadeAlpha(0f, 1f, true);
        yield return new WaitForSeconds(1f);
        sceneUI.SetActive(true);
    }
    public void goBack()
    {
        playUI.SetActive(false);
        StartCoroutine(fade(titleUI));
    }
}
