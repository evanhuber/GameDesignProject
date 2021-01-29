using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectStructure : MonoBehaviour
{
    public GameObject[] generators;
    public GameObject ChooseGenerator()
    {
        int size = generators.Length;
        int random = Random.Range(0, size);
        return generators[random];
    }
    public GameObject[] obstacles;
}
