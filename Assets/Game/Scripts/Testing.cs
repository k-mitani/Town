using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class Testing : ITickable, IStartable
{
    [Inject] Pointer p;

    public void Start()
    {
    }

    public void Tick()
    {
        //var mouse = Mouse.current.position.ReadValue();
        //var ray = Camera.main.ScreenPointToRay(mouse);

        //if (Physics.Raycast(ray, out var hit, 999, p.floorLayerMask))
        //{
        //    p.transform.position = hit.point;
        //}
        //System.Console.WriteLine("uu");
    }
}
