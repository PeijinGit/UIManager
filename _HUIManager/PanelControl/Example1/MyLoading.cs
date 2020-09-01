using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyLoading : MyBasePanel
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loading());
        //print("localPosition: " + transform.localPosition);
        //transform.localPosition = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        //print("localPosition: " + transform.localPosition);
    }

    private IEnumerator Loading() 
    {
        var t = Time.time;
        var img = transform.Find("bottom/Image").GetComponent<Image>();
        img.fillAmount = 0;
        while (true) 
        {
            yield return new WaitForSeconds(0.02f);
            img.fillAmount = (Time.time - t) / 3;
            if (Time.time - t >3) 
            {
                MyUiManager.GetInstance().OffPanel();
                //MyUiManager.GetInstance().PushPanel(MyUiType.MainPanel);
                break;
            }
        }
    }
}
