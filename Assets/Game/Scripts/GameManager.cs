using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameManager : MonoBehaviour
{
    private const float tickIntervalBase = 1;
    [SerializeField] private float tickInterval = tickIntervalBase;

    public event EventHandler<DateTime> TimeChanged;
    public event EventHandler<float> GameSpeedChanged;

    public MapMode MapMode { get; set; }
    private DateTime current;
    private float currentTickInterval;
    
    // Start is called before the first frame update
    void Awake()
    {
        MapMode = MapMode.Select;
        current = DateTime.Parse("2000-04-01 09:00:00");
    }

    private void Update()
    {
        currentTickInterval += Time.deltaTime;
        if (currentTickInterval > tickInterval)
        {
            currentTickInterval = 0;

            // 時間を進める。
            current = current.AddMinutes(1);

            TimeChanged?.Invoke(this, current);
        }
    }

    internal void ChangeGameSpeed(int speed)
    {
        tickInterval = tickIntervalBase / speed;
        GameSpeedChanged?.Invoke(this, speed);
    }

    public void ChangeMapMode(MapMode mode)
    {
        MapMode = mode;
    }
}

public enum MapMode
{
    Select,
    Build,
}
