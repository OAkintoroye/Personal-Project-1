using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Item/details", order = 1)] //creates a menu in the inspector class
public class InventorySystem : ScriptableObject {

	//Q: what attributes does the inventory items have?
	//A: Name,Type,Item image?

	public string itemName = "";
	public int itemValue;
	public string itemType = "";

	//For this example I will make the bottle of water the potions
	//The potions should have the following attributes: Itemname: Potion
	//itemValue:50, and ItemType: Healing

}


