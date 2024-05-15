using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FindBrickState : IState
{
    private float time;
    private float randomTime;
    public void OnEnter(Bot bot)
    {
        time = 0f;
        randomTime = Random.Range(7,10);
        bot.StopMoving();
        bot.ChangeAnim("run");
    }

    public void OnExecute(Bot bot)
    {
        time += Time.deltaTime;


        if (time > randomTime)
        {
            bot.ChangeState(new GoFinishState());
        }

        if (Vector3.Distance(bot.transform.position, bot.DestinationTarget) <= 0.1f)
        {
            bot.ChangeIsDestination(true);
        }
        if (bot.IsSetDestination)
        {
            bot.SetAgentDestination();
            bot.Move();
            bot.ChangeIsDestination(false);
        }
    }

    public void OnExit(Bot bot)
    {
    }
}
