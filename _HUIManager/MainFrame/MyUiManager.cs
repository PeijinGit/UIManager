using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUiManager
{
    private static MyUiManager instance;
    public Transform CanvasTransform;
    UIPanelTypeJ json;

    //存入堆中
    public Stack<MyBasePanel> PanelStack = new Stack<MyBasePanel>();
    private Dictionary<MyUiType, GameObject> PanelCache = new Dictionary<MyUiType, GameObject>();


    private MyUiManager() 
    {
        PanelStack.Clear();
        ParseJson();
        CanvasTransform = GameObject.Find("PanelCanvas").transform;

    }

    public static MyUiManager GetInstance()
    {
        if (instance == null) 
        {
            instance = new MyUiManager();
        }
        return instance;
    }

    /// <summary>
    /// 
    /// </summary>
    
    public void PushPanel(MyUiType panelType) 
    {
        //????
        //if (PanelStack.Count != 0)
        //{
        //    PanelStack.Peek().OnPause();
        //}

        MyBasePanel basePanel = GetPanel(panelType);
        PanelStack.Push(basePanel);
        basePanel.OnEnter();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OffPanel()
    {
        if (PanelStack.Count == 0)
            return;
        MyBasePanel panel = PanelStack.Pop();
        panel.OnExit();

        //if (PanelStack.Count != 0)
        //    PanelStack.Peek().OnResume();
    }


    /// <summary>
    /// 
    /// </summary>
    GameObject instPanel = null;
    private MyBasePanel GetPanel(MyUiType panelType) 
    {
        PanelCache.TryGetValue(panelType,out instPanel);
        //判断缓存中是否有panel
        if (instPanel == null) 
        {
            //find path by Name
            string path = "" ;
            foreach (var item in json.PanelInfoList) 
            {
                if (item.PanelName == panelType.ToString()) 
                {
                    path = item.PanelPath;
                }
            }
            instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            PanelCache.Add(panelType, instPanel);
        }
        else 
        {
            Debug.Log("Using Cache");
           // instPanel = 
        }
        //MyBasePanel mb = instPanel.GetComponent<MyBasePanel>();
        return instPanel.GetComponent<MyBasePanel>();
    }

    public void ParseJson() 
    {
        TextAsset textAsset = Resources.Load<TextAsset>("UIType");
        json = JsonUtility.FromJson<UIPanelTypeJ>(textAsset.text);
    }
    
}

[Serializable]
public class UIPanelTypeJ
{
    public UIPanelInformation[] PanelInfoList;
}

[Serializable]
public class UIPanelInformation
{
    public string PanelName;
    public string PanelPath;
}
