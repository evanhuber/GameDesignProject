using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    //SUBJECT CLASS
    //Controls Generators and Zombie Spawning
    private B scriptB;
    public int state;
    public GameObject scriptBGameObject;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();

        //set the state to be on state 5, this is the starter state
        //scriptB.ChangeState(state);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Originally used to trigger a change in state
    }

    public void ChangeWavePattern(int state)
    {
        //if we have 4 generators left
        //do scriptB.ChangeState(generators)
    }
    public void CheckForChange()
    {
        //if generators
    }
}
