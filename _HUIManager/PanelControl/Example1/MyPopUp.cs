using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyPopUp : MyBasePanel
{
    private Text text;
    private float startTime;
    private float curTime;

    private float exitTime = 0;

    private void Awake()
    {
        text = transform.Find("Image/Text").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time - startTime + exitTime;
        text.text = "time:" + (curTime);
    }

    public void Close() 
    {
        MyUiManager.GetInstance().OffPanel();
    }
    public override void OnEnter()
    {
        base.OnEnter();

        startTime = Time.time;
        canvas.alpha = 0;
        canvas.DOFade(1, 0.2f);

    }
    public override void OnExit()
    {
        base.OnExit();
        exitTime = curTime;
        canvas.alpha = 1;
        canvas.DOFade(0, 0.2f);
    }
}
