using System.Collections;
using System.Collections.Generic;
using FMOD;
using UnityEngine;
using Debug = UnityEngine.Debug;

/// <summary>
/// 存储所有UI信息、创建及销毁UI
/// </summary>
public class UIManager
{
    /// <summary>
    /// 存储所有UI信息的字典，每个UIType对应一个GameObject
    /// </summary>
    private Dictionary<UIType, GameObject> dicUI;

    public UIManager()
    {
        dicUI = new Dictionary<UIType, GameObject>();
    }

    /// <summary>
    /// 创建一个UI
    /// </summary>
    /// <param name="type">UI信息</param>
    /// <returns></returns>
    public GameObject GetSingleUI(UIType type)
    {
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            Debug.LogError("No Canvas");
            return null;
        }

        if (dicUI.ContainsKey(type))
        {
            return dicUI[type];
        }
        Debug.Log(type.Path);
        GameObject ui = GameObject.Instantiate(Resources.Load<GameObject>(type.Path),parent.transform);
        ui.name = type.Name;
        dicUI.Add(type,ui);
        return ui;
    }

    /// <summary>
    /// 销毁一个UI
    /// </summary>
    /// <param name="type">UI信息</param>
    public void DestroyUI(UIType type)
    {
        if (dicUI.ContainsKey(type))
        {
            GameObject.Destroy(dicUI[type]);
            dicUI.Remove(type);
        }
    }
}
