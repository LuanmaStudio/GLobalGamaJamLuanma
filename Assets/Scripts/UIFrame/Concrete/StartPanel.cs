using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 开始面板
/// </summary>
public class StartPanel : BasePanel
{
    private static readonly string path = "Prefabs/UI/Panel/StartPanel";
    
    public StartPanel() : base(new UIType(path)){ }

    public override void OnEnter()
    {
        UITool.GetOrAddComponentInChildren<Button>("Setting").onClick.AddListener(() =>
        {
            //点击事件
            Debug.Log("设置按钮被点了");
            PanelManager.Push(new SettingPanel());
        });
    }
}
