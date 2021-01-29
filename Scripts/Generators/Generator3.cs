using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator3 : MonoBehaviour
{
    bool online = true;
    private B scriptB;
    public GameObject scriptBGameObject;
    private Generators generatorsScript;
    public GameObject generatorsGameObject;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();
        generatorsScript = generatorsGameObject.GetComponent<Generators>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (online)
        {
            Destroyed();
        }
    }

    public void Destroyed()
    {
        Debug.Log("Generator3 has been destroyed");
        generatorsScript.onlineGenerators--;
        online = false;
        //This is to make sure that zombies dont spawn when a generator is destroyed
        //during the phase where zombies are no longer spawning but the player might
        //have to kill the leftover zombies in order to continue
        if (scriptB.coroutineIsRunning == true)
        {
            generatorsScript.UpdateB();
        }

    }

    public void Fixed()
    {
        generatorsScript.onlineGenerators++;
        online = true;
        generatorsScript.UpdateB();
    }
}
