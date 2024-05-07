using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private int enemyStageNumber;

    [SerializeField] private List<Transform> listSameColor;

    [SerializeField] private StageManager stageManager;
    [SerializeField] private NavMeshAgent agent;


    private Vector3 destinationTager;

    [SerializeField] private IState currentState;

    private float minDistance;


    [SerializeField] private bool isSetDestination = true;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        StairStanding();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //agent.SetDestination(hit.point);
            }
        }
        

        if (Vector3.Distance(transform.position, destinationTager) <= 0.1f)
        {
            isSetDestination = true;
        }
        if (isSetDestination)
        {
            Move();
            isSetDestination = false;
        }

        
    }

    private void Move()
    {
        SetAgentDestination();
        agent.SetDestination(destinationTager);
    }

    public void SetAgentDestination()
    {
        if (listSameColor != null)
        {
            int ran = Random.Range(0, listSameColor.Count);
            if (listSameColor[ran].gameObject.tag == Constants.Tag_Brick)
            {
                destinationTager = listSameColor[ran].position;
            }
        }


    }

    public void StopMoving()
    {
        agent.SetDestination(transform.position);
    }
    public void ChangeState(IState newState)
    {
        /*if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }*/
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag(Constants.Tag_StagePoint))
        {
            stageManager = other.gameObject.GetComponent<StageManager>();

            if (enemyStageNumber == stageManager.StageNumber)
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
            destinationTager = listSameColor[0].position;
            minDistance = Vector3.Distance(transform.position, listSameColor[0].position);

            enemyStageNumber = stageManager.StageNumber;
        }
    }
}
