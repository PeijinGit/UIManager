using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyUiManager.GetInstance().PushPanel(MyUiType.FirstPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
