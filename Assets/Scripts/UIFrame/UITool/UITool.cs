using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI管理，获取组件的操作
/// </summary>
public class UITool
{
    private GameObject activePanel;

    public UITool(GameObject panel)
    {
        activePanel = panel;
    }

    /// <summary>
    /// 获取或添加一个组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns></returns>
    public T GetOrAddComponent<T>() where T : Component
    {
        if (activePanel.GetComponent<T>() == null)
        {
            activePanel.AddComponent<T>();
        }

        return activePanel.GetComponent<T>();
    }

    /// <summary>
    /// 查找子对象
    /// </summary>
    /// <param name="name">子对象名称</param>
    /// <returns></returns>
    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }
        Debug.LogWarning($"{activePanel.name}里没有{name}");
        return null;
    }

    /// <summary>
    /// 获取子对象的组件
    /// </summary>
    /// <param name="name">子对象名称</param>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns></returns>
    public T GetOrAddComponentInChildren<T>(string name) where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
            {
                child.AddComponent<T>();
            }

            return child.GetComponent<T>();
        }

        return null;
    }
}
