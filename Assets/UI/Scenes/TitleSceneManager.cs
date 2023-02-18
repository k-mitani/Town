using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI version;
    [SerializeField] private DialogsManager dialogs;

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
        dialogs.Show("�Q�[����ǂݍ��݂܂����H", DialogButton.YesNo, res =>
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
        dialogs.ShowScenarioList();
    }

    public void OnClickOptions()
    {
        dialogs.Show("���b�Z�[�W�e�X�g", DialogButton.YesNoCancel, res =>
        {
            dialogs.Show("����: " + res);
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
        dialogs.Show("�Q�[�����I�����܂����H", DialogButton.YesNo, res =>
        {
            if (res == DialogResult.Yes)
            {
                Application.Quit();
            }
        });
    }
}
