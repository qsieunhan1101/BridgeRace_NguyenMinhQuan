using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float time;
    float timeIdle;
    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        timeIdle = 0.5f;
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;
        if (time >= timeIdle)
        {
            enemy.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Enemy enemy)
    {

    }
}
