using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    private B scriptB;
    public GameObject scriptBGameObject;
    void Start()
    {
        scriptB = scriptBGameObject.GetComponent<B>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        scriptB.zombieCount--;
        Destroy(gameObject);
    }
}
