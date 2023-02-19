using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ButtonsPanel : MonoBehaviour
{
    [Inject] private DialogsManager dialogs;

    public void OnClickBuildingMenu()
    {
        dialogs.ShowInfoMenu();
    }
    
    public void OnClickInfoMenu()
    {
        dialogs.ShowInfoMenu();
    }

    public void OnClickNotificationMenu()
    {
        dialogs.ShowNotificationMenu();
    }

    public void OnClickDeletion()
    {
        dialogs.Show("消去モード");
    }

    public void OnClickRange()
    {
        dialogs.Show("範囲モード");
    }

    public void OnClickOptionsMenu()
    {
        dialogs.ShowOptionsMenu();
    }
}
