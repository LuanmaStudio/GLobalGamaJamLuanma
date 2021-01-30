using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有UIPanel的父类
/// </summary>
public abstract class BasePanel
{
    public  UIType UIType { get; private set; } //UI信息
    public  UITool UITool { get; private set; } //UI管理工具
    
    public PanelManager PanelManager { get; private set; } //面板管理器

    public UIManager UIManager { get; private set; } //UI管理器
    public BasePanel(UIType uiType)
    {
        UIType = uiType;
    }

    /// <summary>
    /// 初始化UITool
    /// </summary>
    /// <param name="tool"></param>
    public void Initalize(UITool tool)
    {
        UITool = tool;
    }

    /// <summary>
    /// 初始化面板管理器
    /// </summary>
    /// <param name="panelManager"></param>
    public void Initalize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    /// <summary>
    /// 初始化UI管理器
    /// </summary>
    /// <param name="uiManager"></param>
    public void Initalize(UIManager uiManager)
    {
        UIManager = uiManager;
    }
    
    /// <summary>
    /// 进入操作
    /// </summary>
    public virtual void OnEnter() {} 
    
    /// <summary>
    /// 暂停操作
    /// </summary>
    public virtual void OnPause() {}
    
    /// <summary>
    /// 继续操作
    /// </summary>
    public virtual void OnResume() {}
    
    /// <summary>
    /// 退出操作
    /// </summary>
    public virtual void OnExit() {}
    
}
