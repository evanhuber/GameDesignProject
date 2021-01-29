using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generators : MonoBehaviour
{
    public int gen1HP = 100;
    public int onlineGenerators;
    private B scriptB;
    public GameObject scriptBGameObject;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();
        //Set generators to 4
        onlineGenerators = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateB()
    {
        scriptB.ChangeState(onlineGenerators);

        //The line below has no purpose, its just to show how to start a Cortoutine from another script
        //StartCoroutine(scriptB.Spawn(5, 5));
    }

    public void Generator1_HP()
    {
        gen1HP -= 5;
        print("Sent from Generators Script: -5hp");
    }
}
