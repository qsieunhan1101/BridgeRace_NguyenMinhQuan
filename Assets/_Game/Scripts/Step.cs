using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] public ColorType stepCurrentColor;

    [SerializeField] private ColorData colorData;
    [SerializeField] private MeshRenderer meshRenderer;

    [SerializeField] private BoxCollider boxCollider;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.isTrigger == false)
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                boxCollider.isTrigger = true;
                time = 0f;
            }

        }


        ChangeColor(stepCurrentColor);
    }

    private void OnInit()
    {
        ChangeColor(ColorType.None);
    }
    private void OnDespawn()
    {

    }

    private void ChangeColor(ColorType colorType)
    {
        stepCurrentColor = colorType;
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
}
