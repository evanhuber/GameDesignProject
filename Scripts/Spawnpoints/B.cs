using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B : MonoBehaviour
{
    //The Spawn Logic script that I left being called B
    int zombieAmount;
    int zombieRate;
    public int zombieCount;
    public bool zombiePhase = true;
    public bool coroutineIsRunning;
    public Text zombiesLeft;
    private SelectZombie randomZombie; //currently not used

    //This connects to each individual spawner script1
    private Spawner1 spawn1Script;
    public GameObject spawn1GameObject;
    private Spawner2 spawn2Script;
    public GameObject spawn2GameObject;
    private Spawner3 spawn3Script;
    public GameObject spawn3GameObject;
    private Spawner4 spawn4Script;
    public GameObject spawn4GameObject;

    //public List<GameObject> cloneList = new List<GameObject>();
    void Start()
    {
        spawn1Script = spawn1GameObject.GetComponent<Spawner1>();
        spawn2Script = spawn2GameObject.GetComponent<Spawner2>();
        spawn3Script = spawn3GameObject.GetComponent<Spawner3>();
        spawn4Script = spawn4GameObject.GetComponent<Spawner4>();
    }

    // Update is called once per frame
    void Update()
    {
        zombiesLeft.text = "Zombies left: " + zombieCount;
    }

    public void ChangeState(int state)
    {
        Debug.Log("We are now in state: " + state);

        if(state == 4){
            //Line Below prevents other instances of a Coroutine to exist 
            StopAllCoroutines();
            zombieAmount = 2;
            zombieRate = 3;
            Debug.Log("Now Spawning: " + zombieAmount + " Zombies every " + zombieRate + " seconds!");
            StartCoroutine(spawn1Script.Spawn1(zombieAmount, zombieRate));
            //StartCoroutine(spawn2Script.Spawn2(zombieAmount, zombieRate));
            //StartCoroutine(spawn3Script.Spawn3(zombieAmount, zombieRate));
            //StartCoroutine(spawn4Script.Spawn4(zombieAmount, zombieRate));
        }
        else if(state == 3){
            StopAllCoroutines();
            zombieAmount = 3;
            zombieRate = 3;
            Debug.Log("Now Spawning: " + zombieAmount + " Zombies every " + zombieRate + " seconds!");
            StartCoroutine(spawn1Script.Spawn1(zombieAmount, zombieRate));
            //StartCoroutine(spawn2Script.Spawn2(zombieAmount, zombieRate));
            //StartCoroutine(spawn3Script.Spawn3(zombieAmount, zombieRate));
            //StartCoroutine(spawn4Script.Spawn4(zombieAmount, zombieRate));
        }
        else if (state == 2)
        {
            StopAllCoroutines();
            zombieAmount = 4;
            zombieRate = 2;
            Debug.Log("Now Spawning: " + zombieAmount + " Zombies every " + zombieRate + " seconds!");
            StartCoroutine(spawn1Script.Spawn1(zombieAmount, zombieRate));
            //StartCoroutine(spawn2Script.Spawn2(zombieAmount, zombieRate));
            //StartCoroutine(spawn3Script.Spawn3(zombieAmount, zombieRate));
            //StartCoroutine(spawn4Script.Spawn4(zombieAmount, zombieRate));
        }
        else if (state == 1)
        {
            StopAllCoroutines();
            zombieAmount = 6;
            zombieRate = 1;
            Debug.Log("Now Spawning: " + zombieAmount + " Zombies every " + zombieRate + " seconds!");
            StartCoroutine(spawn1Script.Spawn1(zombieAmount, zombieRate));
            //StartCoroutine(spawn2Script.Spawn2(zombieAmount, zombieRate));
            //StartCoroutine(spawn3Script.Spawn3(zombieAmount, zombieRate));
            //StartCoroutine(spawn4Script.Spawn4(zombieAmount, zombieRate));
        }
    }

    //When the attack phase timer hits 0, we stop spawning
    //zombies, this is called from the startGamePhases script
    public void StopTheFlow()
    {
        if (coroutineIsRunning == true)
        {
            StopAllCoroutines(); // this might need to be handled in B
            coroutineIsRunning = false;
            Debug.Log("The Spawning Coroutine is now off");
        }

    }


    //I am going to take away the spawn funtion from the spawnLogic script and instead give it to individual
    //Spawner scritps
    //public IEnumerator Spawn(int zombieAmount, int zombieRate)
    //{
    //    coroutineIsRunning = true;
    //    Debug.Log("The Spawning Coroutine is now running");
    //    while (zombiePhase)
    //    {
    //        for (int i = 0; i < zombieAmount; i++)
    //        {
    //            Debug.Log("Spawning Zombie" + i);
    //            zombieCount++;
    //        }
    //        //Line below tells me which state the Coroutine is operating under
    //        Debug.Log("This was done under zombieAmount: " + zombieAmount + " and zombieRate: " + zombieRate);
    //        yield return new WaitForSeconds(zombieRate);
    //    }
    //}



}
