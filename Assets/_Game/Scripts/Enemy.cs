using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private List<Transform> listSameColor;

    [SerializeField] private StageManager stageManager;

    private Vector3 destinationTager;

    private IState currentState;
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
                agent.SetDestination(hit.point);
            }
        }


        //Move();



        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }


    private void Move()
    {
        //lay vi tri dich den??

        agent.SetDestination(destinationTager);
    }

    public void StopMoving()
    {
        agent.SetDestination(transform.position);
    }
    public void ChangeState(IState newState)
    {

    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.gameObject.CompareTag(Constants.Tag_StagePoint))
        {
            stageManager = other.gameObject.GetComponent<StageManager>();
            for (int i = 0; i <= stageManager.listBrickManager.Count - 1; i++)
            {
                if (stageManager.listBrickManager[i].GetComponent<Brick>().brickCurrentColor == this.colorCharacter)
                {
                    listSameColor.Add(stageManager.listBrickManager[i].transform);
                }
            }
        }
    }
}
