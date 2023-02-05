using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public delegate void ClosedHandler(Dialog dialog);
    private ClosedHandler onClosed;

    [SerializeField] private Button closeButton;

    protected virtual void Start()
    {
        if (closeButton != null) closeButton.onClick.AddListener(Close);
    }

    protected virtual void Show(ClosedHandler onClosed = null)
    {
        this.onClosed = onClosed;
        gameObject.SetActive(true);
    }

    protected virtual void Close()
    {
        gameObject.SetActive(false);
        onClosed?.Invoke(this);
    }
}
