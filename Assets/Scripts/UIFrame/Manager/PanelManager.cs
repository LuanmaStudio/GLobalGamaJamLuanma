using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Panel管理器
/// </summary>
public class PanelManager
{
    /// <summary>
    /// 栈存储UIPanel
    /// </summary>
    private Stack<BasePanel> stackPanel;
    /// <summary>
    /// Ui管理器
    /// </summary>
    private UIManager uiManager;
    private BasePanel panel;

    public PanelManager()
    {
        stackPanel = new Stack<BasePanel>();
        uiManager = new UIManager();
    }

    /// <summary>
    /// UI入栈操作，显示第一个面板
    /// </summary>
    /// <param name="nextPanel">要显示的面板</param>
    public void Push(BasePanel nextPanel)
    {
        if (stackPanel.Count > 0)
        {
            panel = stackPanel.Peek();
            panel.OnPause();
        }
        stackPanel.Push(nextPanel);
        GameObject panelGo = uiManager.GetSingleUI(nextPanel.UIType);
        nextPanel.Initalize(new UITool(panelGo));
        nextPanel.Initalize(this);
        nextPanel.Initalize(uiManager);
        nextPanel.OnEnter();
    }

    /// <summary>
    /// Panel的出栈操作
    /// </summary>
    public void Pop()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnResume();
        }
    }

    /// <summary>
    /// Panel的清空操作
    /// </summary>
    public void Clean()
    {
        if (stackPanel.Count > 0)
        {
            stackPanel.Peek().OnExit();
            stackPanel.Pop();
        }
    }
}
