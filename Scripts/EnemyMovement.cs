using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //This script is used by Animated Enemies
    private NavMeshAgent Mob;
    public GameObject Player;
    private Animator anim;
    public float attackProximity = 2.0f;
    public float withinDamageRange = 6.0f;

    // Start is called before the first frame update
    //NOTE
    //If two seperate enemies have the same animation booleans like isWalking in their animator, It will bug out and only play the
    //Animations of one of the two enemies
    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, Player.transform.position);
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            dirToPlayer.y = 0;
            //transform.LookAt(Player.transform);
            Vector3 newPos = transform.position - dirToPlayer;
            anim.SetBool("isIdle", false);


            if (distance > attackProximity)
            {
                Mob.SetDestination(newPos);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
    }

    public void EndAttack()
    {
        float dist = Vector3.Distance(Player.transform.position, this.transform.position);

        if(dist < withinDamageRange)
        {
            Debug.Log("Damage");
        }
    }
}
