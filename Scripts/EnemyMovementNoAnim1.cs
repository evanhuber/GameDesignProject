using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementNoAnim1 : MonoBehaviour
{
    //This script is used by Capsule Enemies
    private NavMeshAgent Mob;
    public GameObject Player;
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Mob.SetDestination(Player.transform.position);
    }
}
