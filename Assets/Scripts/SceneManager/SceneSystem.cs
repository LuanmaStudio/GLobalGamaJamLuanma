using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 场景状态管理
/// </summary>
public class SceneSystem
{
    /// <summary>
    /// 场景状态类
    /// </summary>
    private SceneState sceneState;

    /// <summary>
    /// 设置当前场景并进入当前场景
    /// </summary>
    /// <param name="state"></param>
    public void SetScene(SceneState state)
    {
        sceneState?.OnExit();
        sceneState = state;
        sceneState?.OnEnter();
    }
}
