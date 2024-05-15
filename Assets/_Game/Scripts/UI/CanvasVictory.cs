using UnityEngine;
using UnityEngine.UI;

public class CanvasVictory : UICanvas
{
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;
    private void Awake()
    {
        nextBtn.onClick.AddListener(OnClickNext);
        retryBtn.onClick.AddListener(OnClickRetry);
        mainMenuBtn.onClick.AddListener(OnClickMainMenu);
    }

    public void OnClickNext()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.Gameplay);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.GetLevelInSave());
    }

    public void OnClickRetry()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.Gameplay);
        LevelManager.Instance.DestroyLevel();
        LevelManager.Instance.LoadLevel(LevelManager.Instance.GetLevelInSave() - 1);
        

    }
    public void OnClickMainMenu()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        LevelManager.Instance.DestroyLevel();

    }
}
