using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoMenuDialog : Dialog
{
    public void Show(ClosedHandler onClosed = null)
    {
        //ごみ
        ShowCore(onClosed);
    }

    public void Close()
    {
        CloseCore();
    }
}
