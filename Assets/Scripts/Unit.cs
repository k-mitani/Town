using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using VContainer;

public class Unit : MonoBehaviour
{
    [Inject] private GameManager gm;

    private UnitAnimationManager anim;

    private AIPath aiPath;
    private float aiPathBaseMaxSpeed;
    private float aiPathBaseRotationSpeed;
    private float aiPathBaseSlowDownDistance;

    private bool isStopped;

    private Destination destination;

    // Start is called before the first frame update
    void Start()
    {
        gm.GameSpeedChanged += Gm_GameSpeedChanged;
        
        anim = new UnitAnimationManager(this);
        TryGetComponent(out aiPath);
        aiPathBaseMaxSpeed = aiPath.maxSpeed;
        aiPathBaseRotationSpeed = aiPath.rotationSpeed;
        aiPathBaseSlowDownDistance = aiPath.slowdownDistance;

        isStopped = false;
        anim.StopMoving();
    }

    private void Gm_GameSpeedChanged(object sender, float speed)
    {
        anim.ChangeSpeed(speed);
        aiPath.maxSpeed = speed * aiPathBaseMaxSpeed;
        aiPath.rotationSpeed = speed * aiPathBaseRotationSpeed;
        aiPath.slowdownDistance = speed * aiPathBaseSlowDownDistance;
    }

    // Update is called once per frame
    void Update()
    {
        var prevIsStopped = isStopped;
        isStopped = !aiPath.hasPath || aiPath.reachedEndOfPath;
        if (prevIsStopped != isStopped)
        {
            if (isStopped)
            {
                anim.StopMoving();
                OnMoveComplete();
            }
            else
            {
                anim.StartMoving();
            }
        }
    }

    private void OnMoveComplete()
    {
        if (destination.mode == Destination.Mode.Work)
        {
            // 仕事場から遠いなら何もしない。
            var wpPosition = destination.workplace.transform.position;
            var distance = Vector3.Distance(wpPosition, transform.position);
            if (distance > 2)
            {
                Debug.Log($"仕事開始エラー: 距離: {distance:0.000}");
                return;
            }

            switch (destination.workplace)
            {
                case WoodWorkplace wp:
                    transform.LookAt(wp.transform.position);
                    anim.StartWoodWork();
                    break;
                case MineWorkplace wp:
                    transform.LookAt(wp.transform.position);
                    anim.StartMineWork();
                    break;
                case FarmWorkplace wp:
                    anim.StartFarmWork();
                    break;
            }
        }
    }

    public void GoTo(Destination dest)
    {
        aiPath.destination = dest.position;
        destination = dest;
    }

    private void FootR() { }
    private void FootL() { }
    private void Strike() { }


    private class UnitAnimationManager
    {
        private Unit unit;
        private Animator animator;
        public UnitAnimationManager(Unit unit)
        {
            unit.TryGetComponent(out animator);
        }

        public void StopMoving()
        {
            animator.SetBool("Moving", false);
        }
        public void StartMoving()
        {
            animator.SetBool("Moving", true);
            animator.SetBool("WoodWork", false);
            animator.SetBool("FarmWork", false);
            animator.SetBool("MineWork", false);
        }
        public void StartWoodWork()
        {
            animator.SetBool("WoodWork", true);
        }
        public void StartFarmWork()
        {
            animator.SetBool("FarmWork", true);
        }
        public void StartMineWork()
        {
            animator.SetBool("MineWork", true);
        }

        public void ChangeSpeed(float speed)
        {
            animator.speed = speed;
        }
    }
}

public struct Destination
{
    public enum Mode
    {
        None,
        Move,
        Work,
    }

    public Mode mode;
    public Vector3 position;
    public WorkPlace workplace;
}
