using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //used to accedd UI elements
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    GameObject health;
    int totalhealth = 100;
    int damagerecieved = 100;
    public GameObject deathscreen;
    public bool isdead = false;
    public GameObject[] coins;
    public GameObject wall;
    public int coincounter = 0;
    bool firsttime = false;
	// Use this for initialization
	void Start () {

        health = GameObject.Find("Health");
        coins = GameObject.FindGameObjectsWithTag("coin");

        for (int i = 0; i < coins.Length; i++) {
            coins[i].gameObject.SetActive(false);
        }



    }
    public void StatusReset() {

        totalhealth = 100;
        damagerecieved = 100;
        health.GetComponent<Text>().text = "Health: " + damagerecieved + "/" + totalhealth;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy")
        {
            damagerecieved -= 5;

            health.GetComponent<Text>().text = "Health: " + damagerecieved + "/" + totalhealth;

            if (damagerecieved == 0) {
                isdead = true;
                //Trigger faded screen that reads you have died and ask if want to respawn?
                deathscreen.gameObject.SetActive(true);
                Time.timeScale = 0f; //should pause game
                

            }
        }
        if (col.gameObject.tag == "coin")
            coincounter += 1;
        if(col.gameObject.name == "minipad")
        {
            if (firsttime == false) {
                for (int i = 0; i < coins.Length; i++)
                {
                    coins[i].gameObject.SetActive(true);
                }

                firsttime = true;
            }
            
            if (coincounter == 5)
                wall.gameObject.SetActive(false);
          
        }
    }

   
    
	
}
