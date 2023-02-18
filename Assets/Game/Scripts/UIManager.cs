using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class UIManager : MonoBehaviour
{
    [Inject] GameManager gm;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI foodText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI metalText;
    
    // Start is called before the first frame update
    void Start()
    {
        gm.TimeChanged += Gm_TimeChanged;
    }

    private void Gm_TimeChanged(object sender, DateTime time)
    {
        timeText.text = time.ToString("MM/dd HH:mm");
    }

    public void OnClickChangeGameSpeed(int speedType)
    {
        var speed =
            speedType == 0 ? 0 :
            speedType == 1 ? 1 :
            speedType == 2 ? 10 :
            speedType == 3 ? 100 : 1;
        gm.ChangeGameSpeed(speed);
    }

    public void OnClickBuildMode()
    {
        if (gm.MapMode == MapMode.Build)
        {
            gm.ChangeMapMode(MapMode.Select);
        }
        else
        {
            gm.ChangeMapMode(MapMode.Build);
        }
    }
}
