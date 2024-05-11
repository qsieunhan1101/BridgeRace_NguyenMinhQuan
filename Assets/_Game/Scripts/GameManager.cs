using UnityEngine;


public enum GameState
{
    MainMenu = 0,
    Gameplay = 1,
    Victory = 2,
    Fail = 3,
    Setting = 4,
}
public class GameManager : Singleton<GameManager>
{
    private static GameState currentState;
    public static GameState CurrentState => currentState;

    // Start is called before the first frame update
    void Start()
    {
        /*UIManager.Instance.OpenUI<CanvasMainMenu>();
        ChangeState(GameState.MainMenu);*/
        LevelManager.Instance.LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                MainMenuState();
                break;
            case GameState.Gameplay:
                GamePlayState();
                break;
            case GameState.Setting:
                SettingState();
                break;
            case GameState.Victory:
                VictoryState();
                break;
            case GameState.Fail:
                FailState();
                break;
        }

    }

    private void MainMenuState()
    {
        Time.timeScale = 0;
    }
    private void GamePlayState()
    {
        Time.timeScale = 1;
    }
    private void SettingState()
    {
        Time.timeScale = 0;
    }
    private void VictoryState()
    {
        Time.timeScale = 0;
    }
    private void FailState()
    {
        Time.timeScale = 0;
    }
}
