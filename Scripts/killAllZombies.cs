using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killAllZombies : MonoBehaviour
{
    //Connect to scriptB
    private B scriptB;
    public GameObject scriptBGameObject;
    void Start()
    {
        //Connect component to script B
        scriptB = scriptBGameObject.GetComponent<B>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        scriptB.zombieCount = 0;
    }
}
