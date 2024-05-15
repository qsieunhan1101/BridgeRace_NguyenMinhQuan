
using UnityEngine;

public class GoFinishState : IState
{
    
    public void OnEnter(Bot bot)
    {
        bot.ChangeAnim("run");
    }

    public void OnExecute(Bot bot)
    {

        bot.ChangeDestination(bot.finishBox.position);
        bot.Move();
        if (bot.listCharacterBrick.Count <=0)
        {
            bot.ChangeState(new FindBrickState());
        }
    }

    public void OnExit(Bot bot)
    {
    }
}
