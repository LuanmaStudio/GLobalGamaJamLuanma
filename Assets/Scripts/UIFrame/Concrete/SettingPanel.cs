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
            PanelManager.Pop(); //退出设置面板
        });
        UITool.GetOrAddComponentInChildren<Button>("ExitGame").onClick.AddListener(() =>
        {
            //点击事件
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit(); //退出游戏
        });
        UITool.GetOrAddComponentInChildren<Button>("Change").onClick.AddListener(() =>
        {
            //点击事件
            PanelManager.Push(new ChangePanel());
        });
        UITool.GetOrAddComponentInChildren<Button>("ReStart").onClick.AddListener(() =>
        {
            //点击事件
            Debug.Log("点了一下重新开始");
            PanelManager.Clean();
            GameRoot.Instance.SceneSystem.SetScene(new StartScene());
        });
    }
    
}
