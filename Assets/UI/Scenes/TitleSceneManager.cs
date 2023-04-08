using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI version;
    [SerializeField] private DialogsManager dialogs;
    [SerializeField] private UIDocument uidoc;

    void Start()
    {
        var uiroot = uidoc.rootVisualElement;
        uiroot.Q<Label>("Version").text = $"Ver. {Application.version}";
        uiroot.Q<Button>("Continue").clicked += OnClickContinue;
        uiroot.Q<Button>("LoadGame").clicked += OnClickLoadGame;
        uiroot.Q<Button>("NewGame").clicked += OnClickNewGame;
        uiroot.Q<Button>("Options").clicked += OnClickOptions;
        uiroot.Q<Button>("DLC").clicked += OnClickDlc;
        uiroot.Q<Button>("Credits").clicked += OnClickCredits;
        uiroot.Q<Button>("ExitGame").clicked += OnClickExitGame;
    }

    public void OnClickContinue()
    {
        dialogs.Show("ゲームを読み込みますか？", DialogButton.YesNo, res =>
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
        dialogs.Show("メッセージテスト", DialogButton.YesNoCancel, res =>
        {
            dialogs.Show("結果: " + res);
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
        dialogs.Show("ゲームを終了しますか？", DialogButton.YesNo, res =>
        {
            if (res == DialogResult.Yes)
            {
                Application.Quit();
            }
        });
    }
}
