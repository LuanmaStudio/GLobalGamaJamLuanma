using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SettingPanel : BasePanel
{
    private static readonly string path = "prefabs/UI/Panel/SettingPanel";
    
    public SettingPanel() : base(new UIType(path)){ }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(() =>
        {
            //点击事件
            PanelManager.Pop(); //退出事件
        });
    }

    public override void OnPause()
    {
        
    }

    public override void OnExit()
    {
        UIManager.DestroyUI(UIType);
    }
}
