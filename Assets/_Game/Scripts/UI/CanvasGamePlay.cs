using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGamePlay : UICanvas
{
    [SerializeField] private Button settingBtn;
    private void Awake()
    {
        settingBtn.onClick.AddListener(OnClickSetting);
    }

    public void OnClickSetting()
    {
        UIManager.Instance.OpenUI<CanvasSetting>().SetState(this);
        GameManager.Instance.ChangeState(GameState.Setting);
    }
}
