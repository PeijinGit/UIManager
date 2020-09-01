using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFurPanel : MyBasePanel
{

    private GameObject spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = GameObject.Find("SpawnPos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFur(string name) 
    {
        GameObject instance = Instantiate(Resources.Load<GameObject>("FirstFur/" + name));
        instance.transform.position = spawnPosition.transform.position;
    }
}
