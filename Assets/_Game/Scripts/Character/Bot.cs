using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    [SerializeField] private int botCurrentStage;

    [SerializeField] private List<Transform> listSameColor;

    [SerializeField] private StageManager stageManager;
    [SerializeField] private NavMeshAgent agent;

    public Transform finishBox;


    private Vector3 destinationTarget;
    public Vector3 DestinationTarget => destinationTarget;

    [SerializeField] private IState currentState;



    [SerializeField] private bool isSetDestination = true;
    public bool IsSetDestination => isSetDestination;

    
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        StairStanding();


        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        ChangeState(new IdleState());
    }

    public void Move()
    {
        agent.SetDestination(destinationTarget);
    }

    public void SetAgentDestination()
    {
        if (listSameColor != null)
        {
            int ran = Random.Range(0, listSameColor.Count - 1);

            if (listSameColor[ran].gameObject.tag == Constants.Tag_Brick)
            {
                destinationTarget = listSameColor[ran].position;
            }
            else
            {
                destinationTarget = listSameColor[0].position;
            }
        }


    }

    public void StopMoving()
    {
        destinationTarget = transform.position;
        agent.SetDestination(destinationTarget);
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }


    private void ClearListSameColor()
    {
        listSameColor.Clear();
    }

    public bool ChangeIsDestination(bool a)
    {
        isSetDestination = a;
        return isSetDestination;
    }
    public void ChangeDestination(Vector3 target)
    {
        destinationTarget = target;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag(Constants.Tag_StagePoint))
        {
            ClearListSameColor();
            stageManager = other.gameObject.GetComponent<StageManager>();

            if (botCurrentStage == stageManager.StageNumber)
            {
                return;
            }
            else
            {

                for (int i = 0; i <= stageManager.listBrickManager.Count - 1; i++)
                {
                    if (stageManager.listBrickManager[i].GetComponent<Brick>().brickCurrentColor == this.colorCharacter)
                    {
                        listSameColor.Add(stageManager.listBrickManager[i].transform);
                    }
                }
            }
            destinationTarget = listSameColor[0].position;

            botCurrentStage = stageManager.StageNumber;
        }
        if (other.gameObject.CompareTag(Constants.Tag_FinishBox))
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasFail>();
            GameManager.Instance.ChangeState(GameState.Fail);
        }
    }

}
