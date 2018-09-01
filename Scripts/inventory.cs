using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //used to accedd UI elements
using UnityEngine;
using System.Linq; //helps sort array
using System;

public class inventory : MonoBehaviour {

	public InventorySystem exam;

	public GameObject[] inventoryslots;
	public GameObject[] textslots;
	public Image picture;
	string icon;
	public GameObject[] selectedslots;

	int i = 0; //keeps track of the inventoryslots
	int counter;


	//this script will detect collision with items found in the level
	//if a player collides with a collectable item, it will be picked up and stored in the inventory
	void Start()
	{
		inventoryslots = GameObject.FindGameObjectsWithTag ("Islot").OrderBy(go => go.name).ToArray();
		textslots = GameObject.FindGameObjectsWithTag ("text").OrderBy(go => go.name).ToArray();
		selectedslots = GameObject.FindGameObjectsWithTag ("selectslot").OrderBy(go => go.name).ToArray();

	}

	void Update(){
		bool m = false;
		bool right = false;
		bool left = false;
		bool enter = false;
		if (Input.GetKeyDown (KeyCode.M))
			m = true;
		else if (Input.GetKeyDown (KeyCode.R))
			right = true;
		else if (Input.GetKeyDown (KeyCode.L))
			left = true;
		else if (Input.GetKeyDown (KeyCode.KeypadEnter))
			enter = true;
		deletefrominventory (m, right, left, enter);

	
	}
	void OnCollisionEnter(Collision col)
    {

		//note to self: make a speed potion, change the anim speed multiplier to pull off the effect
		if (col.gameObject.tag == "PotionM") {

			//set the following attributes to the mana potion
			exam.itemName = "Mana Potion";
			exam.itemType = "Healing";
			exam.itemValue = 50;

			icon = "button_set07_c";

			//item information is now stored in the file ItemInfo

			addtoinventory ();

			//delete the mana potion
			Destroy(col.gameObject);
			//can't put destroy outside of if statement, will delete the ground :/
			//refactor later :D
		}

		if (col.gameObject.tag == "PotionH") {

			exam.itemName = "Health Potion";
			exam.itemType = "Healing";
			exam.itemValue = 50;
			icon = "button_set07_b 1";

			addtoinventory ();

			Destroy(col.gameObject);

		}

        if (col.gameObject.tag == "coin")
        {
            exam.itemName = "Coin";
            exam.itemName = "Currency";
            exam.itemValue = 1;
            icon = "coin";

            addtoinventory();

            Destroy(col.gameObject);
        }
	}
		


void addtoinventory(){
	//add game object image to inventory slot
	//things to account for when adding inventory
	//1. make sure each item gets its own slot
	//2. if it is a duplicate item, show the number of item owned
	//3. If inventory is full, print to screen that inventory is full

		//set picture to the image component of inventoryslot[i]
		picture = inventoryslots [i].GetComponent<Image> ();
	//	itemcount = textslots [i].GetComponent<Text> ();
		//if the inventory slot is not active

		if (!(picture.IsActive ())) {
			//set picture to the icon image
			picture.sprite = Resources.Load<Sprite> (icon);
			picture.enabled = true;
			i++;
		}

		if (picture.IsActive ()) {

			for (int j = 0; j < i; j++) {

				print (picture.name + " is being compared to " + inventoryslots [j].name);

				if (picture.sprite == inventoryslots [j].GetComponent<Image> ().sprite) {

					if (picture.name != inventoryslots [j].GetComponent<Image> ().name) {

						int.TryParse (textslots[j].GetComponent<Text>().text, out counter); //converts string to int 
						//grab the current count in text
						counter++; //incrememnt by 1
						textslots[j].GetComponent<Text>().text = counter.ToString (); //store value back in itemcount
						textslots[j].GetComponent<Text>().enabled = true;
						picture.sprite = null;
						picture.enabled = false;
						i--;
					}
				}


			}
		}

}

	void deletefrominventory(bool selection,bool fselect,bool bselect, bool eselect){
		//3/14/18 Note:
		//Instead of doing drag and drop, used a slot selection system for getting ride of items
		//When a player clicks a button (i.e. 'D'), allow them to select from the 6 inventory slots avaliable
		//figure out how to let player know a slot is being selected - green overlay
		//use arrow keys to navigate the slots?
		//trigger a green highlight? yep

		//check if there is an item in that slot
		//if there is not; do nothing
		//if there is, check to see if the player has clicked the enter key
		//when the enter key has been selected, a menu will pop up asking the player how many items they would like to drop
		//On this UI allow for a slider bar, minimum will be 0 max will be the max number of items collected
		//On the UI there should be a confirm/deny buttom (Y/N)
		//The number of items confirmed to be dropped will be placed on the game world
		//if all items are dropped, then the image slot should be erased and deactivated

		int c = 0;
		if (selection) {
			//displays green overlay to inform player that this slot is being selected
			for (int i = 0; i < selectedslots.Length; i++) {
				print (selectedslots [i].name);
			}
			selectedslots [c].GetComponent<Image> ().enabled = true;
			//check for 3 things
			if (fselect && selection) {
				print ("trigger forward");
				//if right arrow, check if there is a slot in front of it
				if (0 <= c && c >= 6) {
					//checking if the value of c is between 0 and 6
					//now check if there are elements in the next slot
					if (inventoryslots [c+1].GetComponent<Image> ().isActiveAndEnabled) {
						//inventory slot is active so there is an item in place
						//deactivate green overlay in current slot and activate in next slot
						selectedslots [c].GetComponent<Image> ().enabled = false;
						c++;
						selectedslots [c].GetComponent<Image> ().enabled = true;
					}

				}
				fselect = false;
			}
			if (bselect && selection) {
				print ("trigger backward");

				//if left arrow, check if there is a slot before it, if not do nothing
				if (0 <= c && c >= 6) {
					//checking if the value of c is between 0 and 6
					//now check if there are elements in the next slot
					if (inventoryslots [c-1].GetComponent<Image> ().isActiveAndEnabled) {
						//inventory slot is active so there is an item in place
						//deactivate green overlay in current slot and activate in next slot
						selectedslots [c].GetComponent<Image> ().enabled = false;
						c--;
						selectedslots [c].GetComponent<Image> ().enabled = true;
					}

				}
				bselect = false;
			}
			if (selection && eselect) {
				print ("trigger enter");

				//if player clicks enter, if player clicks left arrow key and if player clicks right arrow key
				//if enter, check if there is an item of the slot
				eselect = false;
				selection = false;
			}
		}

	}
		



}

//Inventory system:
//
//Check if inventory slot is not active
//	If not active, add image to slot and increment to the next slot
//
//	If active
//	Compare image in current slot to previous slots (length - current slot number)
//	If image matches, increment text

