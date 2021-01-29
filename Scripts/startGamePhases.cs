using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startGamePhases : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime = 7f;
    bool attackPhase;
    bool buyPhase;
    bool startPhase = true;

    //Connect to scriptB
    private B scriptB;
    public GameObject scriptBGameObject;

    //Connect to Generators script
    private Generators generatorsScript;
    public GameObject generatorsGameObject;

    [SerializeField] Text countdownText;
    void Start()
    {
        //Connect component to script B
        scriptB = scriptBGameObject.GetComponent<B>();
        //Connect component to generators script
        generatorsScript = generatorsGameObject.GetComponent<Generators>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            //This is the phase where we explain how the game works
            if (startPhase == true)
            {
                startPhase = false;
                AttackPhase();
            }
            else if (attackPhase == true)
            {
                scriptB.StopTheFlow();
                currentTime = 0;
                if (scriptB.zombieCount == 0)
                {
                    attackPhase = false;
                    BuyPhase();
                }
            }
            else if (buyPhase == true)
            {
                buyPhase = false;
                AttackPhase();
            }
            else currentTime = 0;
        }
    }

    public void AttackPhase()
    {
        Debug.Log("Now on attack phase");
        currentTime = 5;
        attackPhase = true;
        scriptB.zombiePhase = true;
        generatorsScript.UpdateB();
    }

    public void BuyPhase()
    {
        Debug.Log("Now on buy phase");
        currentTime = 3;
        buyPhase = true;
        scriptB.zombiePhase = false;
    }
}
