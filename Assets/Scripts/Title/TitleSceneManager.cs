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
        messageDialog.Show("�Q�[����ǂݍ��݂܂����H", DialogButton.YesNo, res =>
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
        messageDialog.Show("���b�Z�[�W�e�X�g", DialogButton.YesNoCancel, res =>
        {
            messageDialog.Show("����: " + res);
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
        messageDialog.Show("�Q�[�����I�����܂����H", DialogButton.YesNo, res =>
        {
            if (res == DialogResult.Yes)
            {
                Application.Quit();
            }
        });
    }
}
