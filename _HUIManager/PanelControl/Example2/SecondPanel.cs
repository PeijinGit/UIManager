using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPanel : MyBasePanel
{
    private bool infoPStat = true;
    private bool furPStat = false;
    MyUiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = MyUiManager.GetInstance();
        //MyUiManager.GetInstance().PushPanel(MyUiType.ThirdInfoPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void infoPanel() 
    {
        //print("enter INFOR");
        if (infoPStat == true) 
        {
        
        }
        else 
        {
            print("enter ELSE INFOR");
            uiManager.OffPanel();
            uiManager.PushPanel(MyUiType.ThirdInfoPanel);
            infoPStat = true;
            furPStat = false;
        }
        
    }
    public void furPanel()
    {

        //print("enter furPanel");
        if (furPStat == true)
        {

        }
        else
        {
            print("enter ELSE furPanel");
            uiManager.OffPanel();
            uiManager.PushPanel(MyUiType.ThirdFurPanel);
            furPStat = true;
            infoPStat = false;
        }

    }
}
