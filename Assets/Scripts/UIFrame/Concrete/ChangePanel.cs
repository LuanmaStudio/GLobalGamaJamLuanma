using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePanel : BasePanel
{
    private static readonly string path = "prefabs/UI/Panel/ChangePanel";
    
    public ChangePanel() : base(new UIType(path)){ }

    private static bool isW = false;
    private static bool isA = false;
    private static bool isD = false;


    public override void OnEnter()
    {
        if (isW == false)
        {
            UITool.FindChildGameObject("Jump").transform.Find("Key").GetComponent<Text>().text = "&%#";
        }
        if (isA == false)
        {
            UITool.FindChildGameObject("Left").transform.Find("Key").GetComponent<Text>().text = "!*#";
        }
        if (isD == false)
        {
            UITool.FindChildGameObject("Right").transform.Find("Key").GetComponent<Text>().text = "$^&";
        }
        UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(() =>
        {
            //点击事件
            PanelManager.Pop(); 
        });
        UITool.GetOrAddComponentInChildren<Button>("Jump").onClick.AddListener(() =>
        {
            //点击事件
            UITool.FindChildGameObject("Jump").transform.Find("Key").GetComponent<Text>().text = "Space";
            Debug.Log("Jump");
            isW = true;
        });
        UITool.GetOrAddComponentInChildren<Button>("Left").onClick.AddListener(() =>
        {
            //点击事件
            UITool.FindChildGameObject("Left").transform.Find("Key").GetComponent<Text>().text = "A";
            Debug.Log("Left");
            isA = true;
        });
        UITool.GetOrAddComponentInChildren<Button>("Right").onClick.AddListener(() =>
        {
            //点击事件
            UITool.FindChildGameObject("Right").transform.Find("Key").GetComponent<Text>().text = "D";
            Debug.Log("Right");
            isD = true;
        });
    }
    
}
