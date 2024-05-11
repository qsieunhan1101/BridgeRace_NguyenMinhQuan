using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFail : UICanvas
{
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button retryBtn;

    private void Awake()
    {
        retryBtn.onClick.AddListener(OnClickRetry);
        mainMenuBtn.onClick.AddListener(OnClickMainMenu);
    }

    public void OnClickRetry()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.Gameplay);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.GetLevelInSave());
    }
    public void OnClickMainMenu()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        LevelManager.Instance.DestroyLevel();
    }
}
