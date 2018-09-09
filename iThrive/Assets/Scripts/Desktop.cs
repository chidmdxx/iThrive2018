using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Desktop : MonoBehaviour {

    public GameObject windowTemplate;
    public GameObject TaskBarPanel;
    float clickTime=0f,interval=0.5f;
    bool clicked = false;
    public GameObject[] tbIcons;
    private SoundManager soundManager;
    // Use this for initialization
    void Start () {
        soundManager = FindObjectOfType<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {

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
    public void ClickTBIcon()
    {
        Debug.Log("clicked tbicon");
        ResetTBIcons();
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
    }
}
