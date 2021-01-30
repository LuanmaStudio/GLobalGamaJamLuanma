using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储每个UI的信息，包括名字和路径
/// </summary>
public class UIType
{
    public string Name { get; private set; } //名字
    public string Path { get; private set; } //路径

    public UIType(string path)
    {
        Path = path;
        Name = path.Substring(path.LastIndexOf('/') + 1);
        //Debug.Log(Name);
        //Debug.Log(Path);
    }
}
