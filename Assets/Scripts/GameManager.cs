using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameManager : MonoBehaviour
{
    private const float tickIntervalBase = 1;
    [SerializeField] private float tickInterval = tickIntervalBase;
    [SerializeField] private Light sun;

    [field: SerializeField] public float Food { get; private set; }
    [field: SerializeField] public float Wood { get; private set; }
    [field: SerializeField] public float Metal { get; private set; }

    public event EventHandler<DateTime> TimeChanged;
    public event EventHandler<float> GameSpeedChanged;
    
    private DateTime current;
    private float currentTickInterval;
    
    // Start is called before the first frame update
    void Awake()
    {
        current = DateTime.Parse("2000-04-01 09:00:00");
    }

    private void Update()
    {
        currentTickInterval += Time.deltaTime;
        if (currentTickInterval > tickInterval)
        {
            currentTickInterval = 0;

            // ���Ԃ�i�߂�B
            current = current.AddMinutes(1);

            // ���z�̌X����ς���B
            // 6����180�x�A12����90�x�A18����0�x�A24����-90�x�A6����-180�x
            var rotationX = 270 - (current.Hour * 15 + current.Minute * 0.25f);
            const float RotationY = 90;
            sun.transform.rotation = Quaternion.Euler(rotationX, RotationY, 0);


            TimeChanged?.Invoke(this, current);
        }
    }

    internal void ChangeGameSpeed(int speed)
    {
        tickInterval = tickIntervalBase / speed;
        GameSpeedChanged?.Invoke(this, speed);
    }
}
