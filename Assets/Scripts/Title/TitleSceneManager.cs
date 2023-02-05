using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI version;
    [SerializeField] private MessageDialog messageDialog;

    void Start()
    {
        // get version
        version.text = Application.version;
        // get program last update time
        var lastUpdateTime = System.IO.File.GetLastWriteTime(Application.dataPath);

        version.text = $"Ver. {Application.version}";
    }

    public void OnClickContinue()
    {
        messageDialog.Show("ゲームを読み込みますか？", DialogButton.YesNo, res =>
        {
            if (res == DialogResult.Yes)
            {
                SceneManager.LoadScene("LoadingScene");
            }
        });
    }

    public void OnClickLoadGame()
    {
    }

    public void OnClickNewGame()
    {
    }

    public void OnClickOptions()
    {
        messageDialog.Show("メッセージテスト", DialogButton.YesNoCancel, res =>
        {
            messageDialog.Show("結果: " + res);
        });
    }

    public void OnClickDlc()
    {
    }

    public void OnClickCredits()
    {
    }

    public void OnClickExitGame()
    {
        messageDialog.Show("ゲームを終了しますか？", DialogButton.YesNo, res =>
        {
            if (res == DialogResult.Yes)
            {
                Application.Quit();
            }
        });
    }
}
