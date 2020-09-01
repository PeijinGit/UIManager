using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPanel : MyBasePanel
{
    private bool secondPanelStat = false;
    private MyUiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = MyUiManager.GetInstance();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSecondPanel() 
    {
        if (!secondPanelStat) 
        {
            uiManager.PushPanel(MyUiType.SecondPanel);
            uiManager.PushPanel(MyUiType.ThirdInfoPanel);
            secondPanelStat = !secondPanelStat;
        }
        else 
        {
            //注意：count在offpanel()后是会变换的
            for (int i = 0; i< uiManager.PanelStack.Count;i++) 
            {
                uiManager.OffPanel();
            }
            secondPanelStat = !secondPanelStat;
        }
    }
}
