using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListBrickManager : MonoBehaviour
{
    [SerializeField] public List<Brick> listBrickManager;

    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= listBrickManager.Count - 1; i++)
        {
            listBrickManager[i].gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ArrangeListColor()
    {
        for (int i = 0; i<=listBrickManager.Count-1 ; i++)
        {
            if (listBrickManager[i].brickCurrentColor == ColorType.Red)
            {

            }
            
        }
    }
}
