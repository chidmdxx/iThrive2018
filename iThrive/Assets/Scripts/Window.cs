﻿using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public bool IsCurrentWindow { get; set; }
    public Button CloseButton { get; set; }
    protected virtual Action OnStart { get; set; }
    protected virtual Action OnUpdate { get; set; }
    protected virtual Action OnClose { get; set; }

    private bool movable;
    private Vector2 pointerOffset;
    private RectTransform canvasRectTransform;
    private RectTransform panelRectTransform;

    // Use this for initialization
    void Start ()
    {
        this.gameObject.SetActive(false);
        if (this.OnStart != null)
        {
            this.OnStart();
        }

        var buttons = this.GetComponentsInChildren<Button>();
        if (buttons.Any())
        {
            this.CloseButton = buttons.FirstOrDefault(field => field.name.Equals("CloseButton"));
            if (this.CloseButton != null)
            {
                this.CloseButton.onClick.AddListener(this.Close);
            }
        }

        var canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.transform as RectTransform;
            panelRectTransform = transform as RectTransform;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (this.IsCurrentWindow && this.OnUpdate != null)
        {
            this.OnUpdate();
        }
	}

    public void Select()
    {
        this.IsCurrentWindow = true;
        this.gameObject.transform.SetAsLastSibling();
    }

    public void UnSelect()
    {
        this.IsCurrentWindow = false;
    }

    public void Toggle()
    {
        this.IsCurrentWindow = !this.IsCurrentWindow;
    }

    public void Open()
    {
        SoundManager.Instance.PlaySingleSound("click");
        this.Select();
        this.gameObject.SetActive(true);
    }

    public void Close()
    {
        SoundManager.Instance.PlaySingleSound("click");
        if (this.OnClose != null)
        {
            this.OnClose();
        }
        this.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        this.movable = data.pointerCurrentRaycast.gameObject.name.Equals("DragZone");
        this.panelRectTransform.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);

        this.Select();
    }

    public void OnDrag(PointerEventData data)
    {
        if (this.movable && panelRectTransform != null)
        {
            var pointerPostion = this.ClampToWindow(data);

            Vector2 localPointerPosition;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition))
            {
                this.panelRectTransform.localPosition = localPointerPosition - pointerOffset;
            }
        }
    }

    private Vector2 ClampToWindow(PointerEventData data)
    {
        var rawPointerPosition = data.position;

        var canvasCorners = new Vector3[4];
        this.canvasRectTransform.GetWorldCorners(canvasCorners);

        var clampedX = Mathf.Clamp(rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
        var clampedY = Mathf.Clamp(rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

        var newPointerPosition = new Vector2(clampedX, clampedY);
        return newPointerPosition;
    }
}
