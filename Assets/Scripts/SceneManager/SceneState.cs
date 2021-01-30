using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 场景状态
/// </summary>
public abstract class SceneState
{
    /// <summary>
    /// 进入执行的操作
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// 退出执行的操作
    /// </summary>
    public abstract void OnExit();
}
