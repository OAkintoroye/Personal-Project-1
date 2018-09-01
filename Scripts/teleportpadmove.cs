using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportpadmove : MonoBehaviour {
	//since the platform is not being modified manually in the inspector window, it can be hidden.
	//[HideInInspector]
	public GameObject platform;
	int i = 1;

	void Start()
	{	//platform is initialy ground1
		platform = GameObject.Find ("ground1");
	}

	//OnCollisionEnter is called when this collider/rigidbody has begun touching another ridigbody/collider
	void OnCollisionEnter(Collision col)
    {
		//if the tag of the item that has been hit is TeleportpadF or TeleportpadB, then teleport player to the next location
		//note to self: if nothing prints, please check that comments is turned on for the counsole window
		// :/ ya goof!

		if (col.gameObject.tag == "TeleportpadF" || col.gameObject.tag == "TeleportpadB") {
			//print ("Hi, I work!");

			//move player to the next teleport
			//determine how teleportpads will be ordered, player moves to the right platform
			//also, I want to do platforms that go left and right, so figure that out :D

			//idea: instead of teleporting my teleport pads, do teleportation by platforms!!
			//keep track of which platform the player is stand on, and when a she hits a front pad or 
			//back pad, move player accordingly!!!

			//go to the next platform by increasing i count, changing platform and teleporting to name of object

			if (col.gameObject.tag == "TeleportpadF") {
				i++;
			}

			if (col.gameObject.tag == "TeleportpadB") {
				i--;
			}

			//gameObject is recognized as the object it is currently in (in this case the player)
			//the below code will allow the player to teleport to the platform

			//make sure that teleportation stops at the max amount of platforms i.e., if there are
			//5 platforms, the player cannot teleport to ground6 or ground0 :D
			platform = GameObject.Find ("ground" + i);
           // print(platform.name);
            gameObject.transform.position = new Vector3 (platform.transform.position.x, platform.transform.position.y + 2, platform.transform.position.z - 20);
        //platform.transform.position;

		}
            //added because of floating.cs
        if (col.gameObject.tag == "Ground")
        {        //keeps the player from flying off

          
            gameObject.transform.parent = null;

        }
       
        if (col.gameObject.name == "respawnplane")
        {

            gameObject.transform.position = new Vector3(platform.transform.position.x, platform.transform.position.y + 2, platform.transform.position.z);

        }
    }
}
