using UnityEngine;
using UnityEngine.UI;

public class CanvasSetting : UICanvas
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button closeBtn;
    private void Awake()
    {
        mainMenuBtn.onClick.AddListener(OnClickMainMenu);
        continueBtn.onClick.AddListener(OnClickContinue);
        closeBtn.onClick.AddListener(OnClickClose);
    }
    public void SetState(UICanvas canvas)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        if (canvas is CanvasMainMenu)
        {
            buttons[2].gameObject.SetActive(true);
        }
        if (canvas is CanvasGamePlay)
        {
            buttons[0].gameObject.SetActive(true);
            buttons[1].gameObject.SetActive(true);
        }
    }

    public void OnClickMainMenu()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<CanvasMainMenu>();
        GameManager.Instance.ChangeState(GameState.MainMenu);
        LevelManager.Instance.DestroyLevel();
    }

    public void OnClickContinue()
    {
        Close(0);
        GameManager.Instance.ChangeState(GameState.Gameplay);
    }
    public void OnClickClose()
    {
        Close(0);
    }
}
