using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public ColorType colorCharacter;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private ColorData colorData;
    [SerializeField] private GameObject characterBrickPrefab;
    [SerializeField] private Transform characterBrickParent;
    [SerializeField] public List<GameObject> listCharacterBrick;




    [SerializeField] private Transform characterAnimPosStair;



    [SerializeField] protected bool isStair = false;

    public Vector3 rayDist = new Vector3(0, 0, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {


    }
    protected virtual void OnInit()
    {
        //ChangeColor((ColorType)Random.Range(1, 6));
    }

    protected void AddBrick()
    {
        if (characterBrickPrefab != null)
        {
            GameObject newBrick = Instantiate(characterBrickPrefab, characterBrickParent);
            listCharacterBrick.Add(newBrick);
            newBrick.name = $"Brick {listCharacterBrick.Count - 1}";
            newBrick.transform.position = new Vector3(characterBrickParent.position.x, characterBrickParent.position.y + ((int)listCharacterBrick.Count - 1) * 0.4f, characterBrickParent.position.z);
            newBrick.GetComponent<MeshRenderer>().material = colorData.GetMaterial(colorCharacter);
        }
    }
    protected void RemoveBrick()
    {
        if (listCharacterBrick.Count > 0)
        {
            Destroy(listCharacterBrick[listCharacterBrick.Count - 1]);
            listCharacterBrick.RemoveAt(listCharacterBrick.Count - 1);

        }
    }
    protected void ClearBrick()
    {

    }

    protected void ChangeColor(ColorType colorType)
    {
        colorCharacter = colorType;
        skinnedMeshRenderer.material = colorData.GetMaterial(colorType);
    }

    protected void StairStanding()
    {
        Ray ray = new Ray(transform.position + rayDist + Vector3.up * 2, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(transform.position + rayDist + Vector3.up * 2, Vector3.down * 10, Color.red);
        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer(Constants.Layer_Step))
            {
                isStair = true;
                Step step = hit.collider.gameObject.GetComponent<Step>();
                if (step.stepCurrentColor != colorCharacter && listCharacterBrick.Count <= 0)
                {
                    hit.collider.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
        else
        {
            isStair = false;
        }

        if (isStair)
        {
            characterAnimPosStair.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        }
        else if (!isStair)
        {
            characterAnimPosStair.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Constants.Layer_Step) && other.gameObject.GetComponent<Step>().stepCurrentColor != colorCharacter)
        {

            Step step = other.gameObject.GetComponent<Step>();
            if (listCharacterBrick.Count >= 1)
            {
                RemoveBrick();
                step.stepCurrentColor = colorCharacter;
            }

        }
        if (other.gameObject.CompareTag(Constants.Tag_Brick) && other.gameObject.GetComponent<Brick>().brickCurrentColor == colorCharacter)
        {
            MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();
            mesh.enabled = false;
            other.gameObject.tag = Constants.Tag_HiddenBrick;
            AddBrick();
        }
    }

    public void SetChangeColor(int i)
    {
        ChangeColor((ColorType)i);
    }
}
