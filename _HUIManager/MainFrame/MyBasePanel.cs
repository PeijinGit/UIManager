using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBasePanel : MonoBehaviour
{
    protected CanvasGroup canvas;
    public virtual void OnEnter()
    {
        //print("**************enter base panel: "+ this.name);
        if (canvas == null) 
        {
            canvas = GetComponent<CanvasGroup>();
        }
        canvas.alpha = 1;
        canvas.blocksRaycasts = true;
    }

    public virtual void OnExit()
    {
        print("close");
        canvas.alpha = 0;
        canvas.blocksRaycasts = false;

    }

    public virtual void OnPause()
    {
        print("OnPause");
    }
    public virtual void OnResume()
    {
        print("OnResume");
    }
}
