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
        if (closeButton != null) closeButton.onClick.AddListener(CloseCore);
    }

    protected virtual void ShowCore(ClosedHandler onClosed = null)
    {
        this.onClosed = onClosed;
        gameObject.SetActive(true);
    }

    protected virtual void CloseCore()
    {
        gameObject.SetActive(false);
        onClosed?.Invoke(this);
    }
}
