using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    GameObject firstplatform;
    GameObject currentplatform;
    public GameObject Player;
    GameObject deadscreen;

    void Start() {
        firstplatform = GameObject.Find("ground1");
        currentplatform = firstplatform;
    }
  
    public void Respawnclick()
    {
        if (Player.GetComponent<PlayerStatus>().isdead == true)
        {
            Time.timeScale = 1f;
            currentplatform = Player.GetComponent<teleportpadmove>().platform;
            Player.gameObject.transform.position = new Vector3(currentplatform.transform.position.x, currentplatform.transform.position.y + 2, currentplatform.transform.position.z-25);
            Player.GetComponent<PlayerStatus>().deathscreen.SetActive(false);
            Player.GetComponent<PlayerStatus>().StatusReset();
        }
    }
    public void Exitclick()
    {
        //for now respawn to the beginning of the level
        Time.timeScale = 1f;
        Player.gameObject.transform.position = new Vector3(firstplatform.transform.position.x, firstplatform.transform.position.y + 2, firstplatform.transform.position.z - 25);
        Player.GetComponent<PlayerStatus>().deathscreen.SetActive(false);
        Player.GetComponent<PlayerStatus>().StatusReset();
        //return to splash screen
    }

}
