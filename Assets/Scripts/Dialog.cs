using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using NLua;
using DG.Tweening;
using System.Reflection;
using System.IO;

public class Dialog : MonoBehaviour
{

    public TextAsset file;
    
    public float waitTime = 0.2f;

    public static Dialog instance { get; private set; }

    private Text dialogBox;

    private string[] buffer;
    public static Lua lua = new Lua();
    private int currentLine =0;
    private bool canNext = true;
    public bool isPause = false;
    private float varTime = 0.2f;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        dialogBox = GetComponent<Text>();
        //注册方法模板第一次参数:在Lua里叫的函数名,最后一个参数填C#里函数名
        lua.RegisterFunction("w", this, GetType().GetMethod("WaitForWhile"));
        lua.RegisterFunction("print", this, GetType().GetMethod("LPrint"));
        lua.LoadCLRPackage();
        
        buffer = WordsAnalyze.ClipLine(file.text);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0)&&canNext&&!isPause)
        {
            try
            {
                StartCoroutine(PlayText(buffer[currentLine]));
                currentLine++;
            }
            catch (IndexOutOfRangeException e)
            {
                Destroy(this.gameObject);
            }
            

        }
    }

    /// <summary>
    /// 显示文字的协程
    /// </summary>
    /// <param name="Rawtext">切片后的字符串</param>
    /// <returns></returns>
    IEnumerator PlayText(string Rawtext)
    {
        canNext = false;
        List<Mark> mark;
        string text = WordsAnalyze.RemoveKeyWords(Rawtext, out mark);
        dialogBox.text = string.Empty;
        if (text.Length != 0)
        {
            for (int i = 0; i < text.Length; i++)
            {
                dialogBox.text += text[i];
                foreach (var job in mark)
                {
                    if (job.Key == i)
                    {
                        lua.DoString(job.Value);
                    }
                }

                yield return new WaitForSeconds(varTime);

                varTime = waitTime;
            }
        }
        else
        {
            foreach (var job in mark)
            {
               lua.DoString(job.Value);
            }
        }
        canNext = true;
    }
    /// <summary>
    /// 文字等待
    /// </summary>
    /// <param name="time">时间</param>
    public void WaitForWhile(float time)
    {
        varTime = time;
    }
    /// <summary>
    /// 作为Lua调试使用
    /// </summary>
    /// <param name="content">输出的内容</param>
    public void LPrint(string content)
    {
        print(content);
    }
    
    

}
