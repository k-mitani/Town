using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsManager : MonoBehaviour
{
    [SerializeField] private MessageDialog message;
    [SerializeField] private Transform saveDataList;
    [SerializeField] private ScenarioListDialog scenarioList;
    [SerializeField] private InfoMenuDialog infoMenu;
    private RectTransform[] dialogs;

    private void Start()
    {
        dialogs = new[]
        {
            message.GetComponent<RectTransform>(),
            saveDataList.GetComponent<RectTransform>(),
            scenarioList.GetComponent<RectTransform>(),
            infoMenu.GetComponent<RectTransform>(),
        };

        foreach (var d in dialogs)
        {
            d.localPosition = Vector3.zero;
            d.gameObject.SetActive(false);
        }
    }

    public void Show(
        string message,
        DialogButton button = DialogButton.Ok,
        Action<DialogResult> onClosed = null)
        => this.message.Show(message, button, onClosed);

    public void ShowScenarioList()
    {
        scenarioList.Show();
    }

    internal void ShowInfoMenu()
    {
        infoMenu.Show();
    }

    internal void ShowNotificationMenu()
    {
        throw new NotImplementedException();
    }

    internal void ShowOptionsMenu()
    {
        throw new NotImplementedException();
    }
}
