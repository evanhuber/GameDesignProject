using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    //Connects us to script B
    private B scriptB;
    public GameObject scriptBGameObject;

    public GameObject zombieObject;
    public GameObject spawnPoint;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn3(int zombieAmount, int zombieRate)
    {
        scriptB.coroutineIsRunning = true; //from script B
        Debug.Log("The Spawning3 Coroutine is now running");
        GameObject zomibe = zombieObject;
        Vector3 spawnHere = spawnPoint.transform.position;
        while (scriptB.zombiePhase) //from script B
        {
            for (int i = 0; i < zombieAmount; i++)
            {
                Debug.Log("Spawning Zombie" + i);
                Instantiate(zomibe, spawnHere, Quaternion.identity);
                scriptB.zombieCount++; //Also from script B
            }
            //Line below tells me which state the Coroutine is operating under
            Debug.Log("This was done under zombieAmount: " + zombieAmount + " and zombieRate: " + zombieRate);
            yield return new WaitForSeconds(zombieRate);
        }
    }
}
