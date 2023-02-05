using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageDialog : Dialog
{
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Button okButton;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private Button cancelButton;

    public DialogResult Result { get; set; }

    protected override void Start()
    {
        base.Start();
        okButton.onClick.AddListener(() => { Result = DialogResult.Ok; Close(); });
        yesButton.onClick.AddListener(() => { Result = DialogResult.Yes; Close(); });
        noButton.onClick.AddListener(() => { Result = DialogResult.No; Close(); });
        cancelButton.onClick.AddListener(() => { Result = DialogResult.Cancel; Close(); });
    }

    public void Show(
        string message,
        DialogButton button = DialogButton.Ok,
        Action<DialogResult> onClosed = null)
    {
        messageText.text = message;

        Result = DialogResult.Cancel;
        okButton.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        cancelButton.gameObject.SetActive(false);
        switch (button)
        {
            case DialogButton.Ok:
                Result = DialogResult.Ok;
                okButton.gameObject.SetActive(true);
                break;
            case DialogButton.OkCancel:
                okButton.gameObject.SetActive(true);
                cancelButton.gameObject.SetActive(true);
                break;
            case DialogButton.YesNo:
                Result = DialogResult.No;
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
                break;
            case DialogButton.YesNoCancel:
                yesButton.gameObject.SetActive(true);
                noButton.gameObject.SetActive(true);
                cancelButton.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        base.Show(_ => onClosed?.Invoke(Result));
    }

    protected override void Close()
    {
        base.Close();
    }
}

public enum DialogButton
{
    Ok = 0,
    OkCancel,
    YesNo,
    YesNoCancel,
}

public enum DialogResult
{
    Ok = 0,
    Cancel,
    Yes,
    No,
}
