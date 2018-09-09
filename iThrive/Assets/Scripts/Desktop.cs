using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Desktop : MonoBehaviour {

    public GameObject windowTemplate;
    public GameObject TaskBarPanel;
    public GameObject bubble;
    public GameObject speech;
    Queue<string> outsideDialog;

    float clickTime=0f,interval=0.5f;
    bool clicked = false;
    public GameObject[] tbIcons;
    private SoundManager soundManager;
    // Use this for initialization
    void Start () {
        soundManager = FindObjectOfType<SoundManager>();
        bubble.SetActive(false);
        speech.SetActive(false);
        outsideDialog = new Queue<string>();
        outsideDialog.Enqueue("Hi");
        outsideDialog.Enqueue("Bye");
	}
	
	// Update is called once per frame
	void Update () {

    }

    void DisplayBubble(string text)
    {
        // Thought bubble for player
        bubble.SetActive(true);
        bubble.GetComponentInChildren<Text>().text = text;
    }
    void DisplaySpeech(string text)
    {
        // Speech bubble for oustide characters like mom
        speech.SetActive(true);
        speech.GetComponentInChildren<Text>().text = text;
    }

    void ResetTBIcons()
    {
        tbIcons = GameObject.FindGameObjectsWithTag("TBIcon");
        foreach(GameObject icon in tbIcons)
        {
            icon.GetComponent<Button>().interactable = true;
        }
    }
    void OpenWindow(string iconName)
    {
        ResetTBIcons();
        GameObject tbIcon = Instantiate(windowTemplate) as GameObject;
        tbIcon.transform.SetParent(TaskBarPanel.transform, false);
        tbIcon.GetComponentInChildren<Text>().text = iconName;
        tbIcon.GetComponent<Button>().interactable = false;
        tbIcon.GetComponent<Button>().onClick.AddListener(ClickTBIcon);

    }
    public void ClickIcon()
    {

        soundManager.PlaySingleSound("Click");
        if ((clickTime + interval) > Time.time)
        {
            Debug.Log("Double Click");
            OpenWindow(EventSystem.current.currentSelectedGameObject.name);
        }
        else
        {
            clickTime = Time.time;
        }
    }
    public void AdvanceDialog()
    {
        GameObject currObj = EventSystem.current.currentSelectedGameObject;
        if(outsideDialog.Count > 0)
        {
            currObj.GetComponentInChildren<Text>().text = outsideDialog.Dequeue();
        }
        else
        {
            //Close the dialog bubble
            currObj.SetActive(false);
        }
    }

    /*
     * First choose to activate bubble or speech by doing either DisplaySpeech or DisplayBubble and the first item of the queue
     * Then use AdvanceDialog() which will keep feeding the queue of dialogs to the already active bubble or speech
     * */

    public void ClickTBIcon()
    {
        ResetTBIcons();
        DisplaySpeech(outsideDialog.Dequeue());
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
    }
}
