using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggercloseby : MonoBehaviour {

	 public bool playerisnear;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "Player") {
			playerisnear = true;
		}

	}

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player") {
            playerisnear = false;
        }
    }
		
}
