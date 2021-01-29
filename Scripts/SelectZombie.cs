using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectZombie : MonoBehaviour
{
    public GameObject[] zombie;

    public GameObject GetZombie()
    {
        int size = zombie.Length;
        int random = Random.Range(0, size);
        return zombie[random];
    }
}
