using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrawlerMovement : MonoBehaviour
{
    //This script is used by Crawling Animated Enemies
    private NavMeshAgent Mob;
    //public GameObject Gen1;
    private GameObject nextTarget;
    private Animator anim;
    public float attackProximity = 2.0f;
    public float withinDamageRange = 6.0f;
    bool gen1 = false;

    //Generators
    private Generators generatorsScript;
    public GameObject generatorsGameObject;
    private Generator1 generator1Script;
    public GameObject generator1GameObject;


    void Start()
    {
        Mob = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        generator1Script = generator1GameObject.GetComponent<Generator1>();
        generatorsScript = generatorsGameObject.GetComponent<Generators>();
        SelectNextTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (gen1)
        {
            float distance = Vector3.Distance(transform.position, generator1GameObject.transform.position);
            Vector3 dirToPlayer = transform.position - generator1GameObject.transform.position;
            dirToPlayer.y = 0;
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
        
    }

    public void SelectNextTarget()
    {
        int random = Random.Range(1, 4);
        switch (1)//CHANGE THIS VALUE WHEN ITS WORKING WITH 1 GENERATOR
        {
            case 4:
                print("Hello and good day!");
                break;
            case 3:
                print("Whadya want?");
                break;
            case 2:
                print("Grog SMASH!");
                break;
            case 1:
                gen1 = true;
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }

    public void EndAttack()
    {
        if (gen1)
        {
            //need some sort of logic here once gen1's HP is 0
            float dist = Vector3.Distance(generator1GameObject.transform.position, this.transform.position);
            if (dist < withinDamageRange)
            {
                generatorsScript.Generator1_HP();
            }
        }

    }
}
