using UnityEditor;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform rotationPlayer;
    private Vector2 startPos, currentPos;
    private Vector2 screen;
    private Vector2 MousePosition => new Vector2(Input.mousePosition.x, Input.mousePosition.y) - screen / 2;
    private Vector2 TouchPosition => Input.GetTouch(0).position - screen / 2;
    private Vector3 direction;
    private Vector3 rotationDirect;

    //[SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        GetDirection();
        GetRotationState();
        StairStanding();
        //RayCheckStair();

        ChangeColor(colorCharacter);

        
        Debug.Log(transform.forward);
    }
    private void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        rb.velocity = new Vector3(direction.x*speed, rb.velocity.y, direction.z*speed);
    }
    private void ChangeAnim()
    {

    }

    private void GetDirection()
    {
        //man hinh thong thuong
        /*if (Input.GetMouseButtonDown(0))
        {
            startPos = MousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            currentPos = MousePosition;
            direction = (currentPos - startPos).normalized;
            direction.z = direction.y;
            direction.y = 0;
           
            //Debug.Log(direction);
        }
        if (Input.GetMouseButtonUp(0))
        {
            direction = Vector3.zero;
        }*/
        


        //man hinh dien thoai
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startPos = TouchPosition;
               
            }
            if (touch.phase == TouchPhase.Moved)
            { 
                currentPos = TouchPosition;
                direction = (currentPos - startPos).normalized;
                direction.z = direction.y;
                direction.y = 0;
                rotationDirect = direction;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                direction = Vector3.zero;
            }
        }
    }

    private void GetRotationState()
    {
        rotationPlayer.rotation = Quaternion.LookRotation(rotationDirect);
    }

}
