using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] public MeshRenderer meshRenderer;
    [SerializeField] private ColorData colorData;
    private float time;
    [SerializeField] private int timeToEnable = 5;
    public ColorType brickCurrentColor;


    private void Awake()
    {
        OnInit();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (meshRenderer.enabled == false)
        {
            time += Time.deltaTime;
            if (time >= timeToEnable)
            {
                ChangeToVisible();
                time = 0.0f;
            }
        }

    }
    private void OnInit()
    {

        ChangeColor((ColorType)Random.Range(1, 6));
    }
    private void OnDespawn()
    {

    }

    private void ChangeColor(ColorType colorType)
    {
        brickCurrentColor = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
    private void ChangeToVisible()
    {
        this.gameObject.tag = "Brick";
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        box.enabled = false;
        meshRenderer.enabled = true;
        box.enabled = true;
    }
}
