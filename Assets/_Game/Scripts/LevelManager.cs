using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject botPrefab;

    [SerializeField] private List<GameObject> levelPrefabs;

    [SerializeField] private CameraFollow cameraMain;

    private GameObject mapInstantiate;
    private GameObject playerInstantiate;
    private GameObject botInstantiate;

    [SerializeField] private GameObject levelParent;
    private List<int> colors;

    [SerializeField] private StartPointManager startPointManager;


    public int level;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoadLevel(int levelIndex)
    {
        DestroyLevel();
        GameObject levelParent = new GameObject("LevelParent");
        this.levelParent = levelParent;

        colors = new List<int>() { 1, 2, 3, 4, 5 };
        //load map

        mapInstantiate = Instantiate(levelPrefabs[levelIndex], this.levelParent.transform);
        //load player
        startPointManager = mapInstantiate.GetComponent<StartPointManager>();
        playerInstantiate = Instantiate(playerPrefab,this.levelParent.transform);
        playerInstantiate.gameObject.GetComponent<Player>().SetChangeColor(colors[0]);
        colors.Remove(colors[0]);
        playerInstantiate.transform.position = startPointManager.startPoints[0].transform.position;
        startPointManager.startPoints.Remove(startPointManager.startPoints[0]);
        //set up camera cho player
        cameraMain.target = playerInstantiate;
        cameraMain.SetUpCamera();
        //load bot
        for (int i=0; i< 4; i++)
        {
            botInstantiate = Instantiate(botPrefab, this.levelParent.transform);
            botInstantiate.transform.position = startPointManager.startPoints[i].transform.position;
            botInstantiate.gameObject.GetComponent<Bot>().finishBox = startPointManager.endPoint.transform;
            botInstantiate.gameObject.GetComponent<Bot>().SetChangeColor(colors[i]);
        }
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(Constants.Level_Save, level);
    }
    public int GetLevelInSave()
    {
        return PlayerPrefs.GetInt(Constants.Level_Save);
    }

    public void DestroyLevel()
    {
        if (this.levelParent != null)
        {
            Destroy(this.levelParent);
            Debug.Log("destroy level");
        }
    }
}
