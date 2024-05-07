using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FindBrickState : IState
{
    private float time;
    private float randomTime;
    public void OnEnter(Enemy enemy)
    {
        time = 0f;
        randomTime = Random.Range(5,8);
    }

    public void OnExecute(Enemy enemy)
    {
        time += Time.deltaTime;

        enemy.SetAgentDestination();


        if (time > randomTime)
        {
            enemy.ChangeState(new GoFinishState());
        }
    }

    public void OnExit(Enemy enemy)
    {
    }
}
