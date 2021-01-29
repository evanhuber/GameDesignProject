using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class backupMovement : MonoBehaviour
{
    private NavMeshAgent Mob;
    public GameObject Player;
    public float MobDistanceRun = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        // Run towards Player
        if (distance < MobDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            dirToPlayer += new Vector3(0, 1, 0);
            //dirToPlayer.y = 0;
            //test code below
            transform.LookAt(Player.transform);
            Vector3 newPos = transform.position - dirToPlayer;
            Mob.SetDestination(newPos);
        }
    }
}
