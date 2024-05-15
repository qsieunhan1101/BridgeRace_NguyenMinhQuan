using UnityEngine;
using UnityEngine.UI;

public class CanvasMainMenu : UICanvas
{
    [SerializeField] private Button startGameBtn;
    [SerializeField] private Button continueBtn;
    private void Awake()
    {
        startGameBtn.onClick.AddListener(OnClickStartGame);
        continueBtn.onClick.AddListener(OnClickContinue);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickStartGame()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.Gameplay);
        LevelManager.Instance.level = 0;
        LevelManager.Instance.SaveLevel();
        LevelManager.Instance.LoadLevel(LevelManager.Instance.GetLevelInSave());
    }

    public void OnClickContinue()
    {
        Close(0);
        UIManager.Instance.OpenUI<CanvasGamePlay>();
        GameManager.Instance.ChangeState(GameState.Gameplay);
        LevelManager.Instance.LoadLevel(LevelManager.Instance.GetLevelInSave());
    }
}
