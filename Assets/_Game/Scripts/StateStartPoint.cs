using UnityEngine;

public class StateStartPoint : MonoBehaviour
{

    [SerializeField] private ListBrickManager list;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Character charac = other.gameObject.GetComponent<Character>();
            for (int i = 0; i <= list.listBrickManager.Count - 1; i++)
            {
                if (list.listBrickManager[i].brickCurrentColor == charac.colorCharacter)
                {
                    list.listBrickManager[i].gameObject.SetActive(true);

                }

            }
            gameObject.SetActive(false);
        }
    }
}
