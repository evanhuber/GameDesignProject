using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    //Variables
    public Transform spawnPoint;
    public float distance = 15f;

    //-public AudioSource shootSound;
    //public GameObject muzzle;
    //public GameObject impact;

    public Transform initialPos;
    public Transform aimPosition;

    bool isAiming;

    //private EnemyHeath enemyHealthScript;
    //public GameObject enemyHealthObject;
    //ReloadScript ammoScript;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        //ammoScript = GetComponent<ReloadScript>();
        //enemyHealthScript = enemyHealthObject.GetComponent<EnemyHeath>();
        transform.position = initialPos.position;
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))//&& !ammoScript.needReload
            Shoot();

        //Aim
        if (Input.GetButtonDown("Fire2") && !isAiming)
            Aim();
        else if (Input.GetButtonUp("Fire2"))
            UnAim();
    }

    //Method to shoot bullets
    private void Shoot()
    {
        //Variables
        RaycastHit hit;
        EnemyHealth enemyHealth;

        //shootSound.Play();
        //ammoScript.currentAmmo--;

        //GameObject muzzleInstance = Instantiate(muzzle, spawnPoint.position, spawnPoint.rotation);
        //muzzleInstance.transform.parent = spawnPoint;

        if (Physics.Raycast(spawnPoint.position, spawnPoint.forward, out hit, distance)) //used to be spawnPoint.forward
        {
            Debug.Log("Hit");

            //Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            if (hit.transform.tag == "Enemy")
            {
                enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                enemyHealth.health--;
                //enemyHealthScript.health--;
                //Debug.Log(enemyHealthScript.health);
            }

        }
        else
            Debug.Log("Not Hit");

    }

    //Aim and Unaim methods
    void Aim()
    {
        transform.position = aimPosition.position;
        isAiming = true;
    }

    void UnAim()
    {
        transform.position = initialPos.position;
        isAiming = false;
    }
}
