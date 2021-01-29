using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    //Connects us to script B
    private B scriptB;
    public GameObject scriptBGameObject;

    public GameObject zombieObject;
    public GameObject spawnPoint;
    public float minDistance = -25.0f;
    public float maxDistance = 25.0f;
    public float xBuffer = 10.0f;
    public float zBuffer = 10.0f;
    private float xPosition;
    private float zPosition;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn1(int zombieAmount, int zombieRate)
    {
        scriptB.coroutineIsRunning = true; //from script B
        GameObject zomibe = zombieObject;

        while (scriptB.zombiePhase) //from script B
        {
            for (int i = 0; i < zombieAmount; i++)
            {
                Vector3 spawnHere = spawnPoint.transform.position;
                xPosition = UnityEngine.Random.Range(minDistance, maxDistance);
                zPosition = UnityEngine.Random.Range(minDistance, maxDistance);
                while (xPosition <= xBuffer && xPosition >= -xBuffer && zPosition >= -zBuffer && zPosition <= zBuffer)
                {
                    xPosition = UnityEngine.Random.Range(minDistance, maxDistance);
                    zPosition = UnityEngine.Random.Range(minDistance, maxDistance);
                }
                Vector3 randomPositions = new Vector3(spawnHere.x + xPosition, 10, spawnHere.z + zPosition);
                Instantiate(zomibe, randomPositions, Quaternion.identity);
                scriptB.zombieCount++; //Also from script B
            }
            //Line below tells me which state the Coroutine is operating under
            Debug.Log("This was done under zombieAmount: " + zombieAmount + " and zombieRate: " + zombieRate);
            yield return new WaitForSeconds(zombieRate);
        }
    }
}
