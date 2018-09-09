using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InternetWindow : Window {

    public GameObject homePage;
    public GameObject loadingPage;
    public GameObject header;
    public Text URLText;
    GameObject currentPage;

	public void NavigateToPage(GameObject newPage)
    {
        currentPage.SetActive(false);
        currentPage = newPage;
        currentPage.SetActive(true);
    }

    public void OnEnable()
    {
        currentPage = homePage;
        currentPage.SetActive(true);
        header.SetActive(true);
    }

    public void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
