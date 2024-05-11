using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update
    [SerializeField] private GameObject mapPrefap;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject botPrefab;

    [SerializeField] private CameraFollow camera;

    private GameObject mapInstantiate;
    private GameObject playerInstantiate;
    private GameObject botInstantiate;

    private List<int> colors;

    [SerializeField] private StartPointManager startPointManager;

    float randomIndex;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel()
    {
        colors = new List<int>() { 1, 2, 3, 4, 5 };
        mapInstantiate = Instantiate(mapPrefap);
        startPointManager = mapInstantiate.GetComponent<StartPointManager>();

        playerInstantiate = Instantiate(playerPrefab);

        playerInstantiate.gameObject.GetComponent<Player>().SetChangeColor(colors[0]);
        colors.Remove(colors[0]);
        playerInstantiate.transform.position = startPointManager.startPoints[0].transform.position;
        camera.target = playerInstantiate;
        camera.SetUpCamera();
        startPointManager.startPoints.Remove(startPointManager.startPoints[0]);

        for (int i=0; i< 4; i++)
        {
            botInstantiate = Instantiate(botPrefab);
            botInstantiate.transform.position = startPointManager.startPoints[i].transform.position;
            botInstantiate.gameObject.GetComponent<Bot>().SetChangeColor(colors[i]);
        }
    }
}
