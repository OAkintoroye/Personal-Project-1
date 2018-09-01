using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Monstermove : MonoBehaviour {
	bool range;
	public GameObject thinggy;
    public GameObject target;
    public Transform posa, posb;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update() {
        //thinggy is the invisable sphere that tracks the position of the player
        range = thinggy.GetComponent<triggercloseby>().playerisnear;

       // print("Current range status: " + range);
        if (range == true)
        {
            transform.LookAt(target.transform);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            agent.destination = target.transform.position;
            // transform.Translate(target.transform.position.x, transform.position.y, target.transform.position.z);
         
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;

            

             agent.destination = new Vector3(PingPong(Time.time * 5, posa.position.x,posb.position.x),transform.position.y,transform.position.z);
            // agent.nextPosition = posb.position;
            //agent.destination = posb.position;


            // transform.position = new Vector3(PingPong(Time.time * 5, -42, 14), transform.position.y, transform.position.z);

        }
    }

   	  
	//void OnCollisionEnter(Collision col){

	//	if (col.gameObject.name == "Player") {

	//		transform.position = col.transform.position;
	//	}
	//}
	float PingPong(float t, float min, float max){

        return Mathf.PingPong(t, max - min) + min;
	}

}
