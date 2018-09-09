using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    public GameObject titleUI;
    public GameObject deskUI;
    public GameObject pauseUI;
    public Image blackScreen;
    private AudioSource chairRoll;

	// Use this for initialization
	void Start () {
        chairRoll = blackScreen.gameObject.GetComponent<AudioSource>();
        blackScreen.canvasRenderer.SetAlpha(0.0f);
        Player.PauseTime();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && deskUI.active)
        {
            //Pause game
            pauseUI.SetActive(true);
            Player.PauseTime();
        }
	}

    public void Play() {
        titleUI.SetActive(false);
        StartCoroutine(Fade(deskUI));
        Player.SetTimeToNormal();
    }
    public void Resume()
    {
        pauseUI.SetActive(false);
        Player.SetTimeToNormal();
    }
    public void MainMenu()
    {
        deskUI.SetActive(false);
        pauseUI.SetActive(false);
        StartCoroutine(Fade(titleUI));
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
        blackScreen.gameObject.SetActive(true);
        blackScreen.CrossFadeAlpha(1.0f, 2f, true);
        yield return new WaitForSeconds(2f);
        //Play chair rolling back audio clip
        chairRoll.Play();
        blackScreen.CrossFadeAlpha(0.0f, 1f, true);
        yield return new WaitForSeconds(1f);
        sceneUI.SetActive(true);
        blackScreen.gameObject.SetActive(false);
    }
    public void GoBack()
    {
        deskUI.SetActive(false);
        StartCoroutine(Fade(titleUI));
    }

}
