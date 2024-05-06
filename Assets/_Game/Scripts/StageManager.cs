using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{

    [SerializeField] public List<GameObject> listBrickManager;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= listBrickManager.Count - 1; i++)
        {
            listBrickManager[i].SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tag_Player) || other.gameObject.CompareTag(Constants.Tag_Enemy))
        {
            Character charac = other.gameObject.GetComponent<Character>();
            for (int i = 0; i <= listBrickManager.Count - 1; i++)
            {
                if (listBrickManager[i].GetComponent<Brick>().brickCurrentColor == charac.colorCharacter)
                {
                    listBrickManager[i].gameObject.SetActive(true);
                }

            }
            gameObject.SetActive(false);
        }
    }
}
