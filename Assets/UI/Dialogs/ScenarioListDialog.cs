using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioListDialog : Dialog
{
    public void Show(ClosedHandler onClosed = null)
    {
        ShowCore(onClosed);
    }

    public void Close()
    {
        CloseCore();
    }

    public void OnClickStartGame(ScenarioMasterData scenario)
    {
        LoadingSceneManager.LoadScene(scenario);
    }
}
