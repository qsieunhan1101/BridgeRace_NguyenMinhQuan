using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    float time;
    float timeIdle;
    public void OnEnter(Bot bot)
    {
        bot.StopMoving();
        bot.ChangeAnim("idle");
        timeIdle = 1f;
    }

    public void OnExecute(Bot bot)
    {
        time += Time.deltaTime;
        if (time >= timeIdle)
        {
            bot.ChangeState(new FindBrickState());
        }
        
    }

    public void OnExit(Bot bot)
    {

    }
}
