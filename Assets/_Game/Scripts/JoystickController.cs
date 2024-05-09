using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public delegate void JoystickDirection(Vector3 direction);
    public JoystickDirection directionEvent;
    [SerializeField] private GameObject joystick;
    [SerializeField] private RectTransform bg, knob;
    [SerializeField] private float knobRange;
    private Vector2 startPos, currentPos;
    private Vector2 screen;

    private Vector2 MousePosition => new Vector2(Input.mousePosition.x, Input.mousePosition.y) - screen / 2;

    private Vector2 TouchPosition => Input.GetTouch(0).position - screen / 2;


    private Vector2 TP
    {
        get
        {
            Vector2 screenSize = new Vector2(Screen.width, Screen.height);
            Vector2 screenCenter = screenSize / 2f;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                return touch.position - screenCenter;
            }
            else
            {
                return Vector2.zero;
            }
        }
    }
    private void Awake()
    {
        screen.x = Screen.width;
        screen.y = Screen.height;
    }


    // Start is called before the first frame update
    void Start()
    {
        joystick.SetActive(false);
        //directionEvent?.Invoke(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        ////Man hinh thong thuong
        /* if (Input.GetMouseButtonDown(0))
         {
             startPos = MousePosition;
             joystick.SetActive(true);
             bg.anchoredPosition = startPos;
         }
         if (Input.GetMouseButton(0))
         {
             currentPos = MousePosition;
             knob.anchoredPosition = Vector3.ClampMagnitude((currentPos - startPos), knobRange) + startPos;
             Vector3 direction = (currentPos - startPos).normalized;
             direction.z = direction.y;
             direction.y = 0;
             //directionEvent?.Invoke(direction);
             //Debug.Log(direction);
         }
         if (Input.GetMouseButtonUp(0))
         {
             joystick.SetActive(false);
            // directionEvent?.Invoke(Vector3.zero);
         }*/
        //Man hinh dien thoai
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                startPos = TP;
                joystick.SetActive(true);
                bg.anchoredPosition = startPos;
                knob.anchoredPosition = startPos;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                currentPos = TP;
                knob.anchoredPosition = Vector2.ClampMagnitude((currentPos - startPos), knobRange) + startPos;
                //Debug.Log(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));
            }
            if (touch.phase == TouchPhase.Ended)
            {
                joystick.SetActive(false);

            }
        }
    }
}
