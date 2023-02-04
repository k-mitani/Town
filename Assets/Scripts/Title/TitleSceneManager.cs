using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI version;

    void Start()
    {
        version.text = $"Ver. {Application.version}";
    }

    public void OnClickContinue()
    {
    }

    public void OnClickLoadGame()
    {
    }

    public void OnClickNewGame()
    {
    }

    public void OnClickOptions()
    {
    }

    public void OnClickDlc()
    {
    }

    public void OnClickCredits()
    {
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
