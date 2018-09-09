using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public GameObject titleUI;
    public GameObject playUI;
    public Image blackScreen;
    private AudioSource chairRoll;

	// Use this for initialization
	void Start () {
        chairRoll = blackScreen.gameObject.GetComponent<AudioSource>();
        blackScreen.canvasRenderer.SetAlpha(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {
        Debug.Log("Transition to play cutscene");
        titleUI.SetActive(false);
        StartCoroutine(Fade(playUI));
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
    IEnumerator Fade(GameObject sceneUI)
    {
        blackScreen.CrossFadeAlpha(1.0f, 2f, true);
        yield return new WaitForSeconds(2f);
        //Play chair rolling back audio clip
        chairRoll.Play();
        blackScreen.CrossFadeAlpha(0.0f, 1f, true);
        yield return new WaitForSeconds(1f);
        sceneUI.SetActive(true);
    }
    public void GoBack()
    {
        playUI.SetActive(false);
        StartCoroutine(Fade(titleUI));
    }
}
