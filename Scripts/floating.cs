using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating : MonoBehaviour {
    // Update is called once per frame

    bool ffloat;
    GameObject pivot;
    void Start() {
        pivot = GameObject.Find("ground4");
        if (gameObject.tag == "floatturn1")
            ffloat = false;
        if (gameObject.tag == "floatturn2")
            ffloat = true;
    }
    void Update () {

        if (ffloat == false)
        {
            StartCoroutine(Floatup());
            
  
        }

        else {
            StartCoroutine(Floatdown());
            
            
        }
               
        
        
	}

    IEnumerator Wait() {
        yield return new WaitForSeconds(6);
    }
    IEnumerator Floatup() {
        transform.position = new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
        //  transform.RotateAround(new Vector3(195.1851f, 84.17151f, 143.4455f), Vector3.up, 20 * Time.deltaTime);
        transform.RotateAround(pivot.transform.position, pivot.transform.up, 10 * Time.deltaTime);
        yield return new WaitForSeconds(5);
        ffloat = true; 
    }
    IEnumerator Floatdown() {
        transform.position = new Vector3(transform.position.x, transform.position.y - .1f, transform.position.z);
        //  transform.RotateAround(new Vector3(195.1851f, 84.17151f, 143.4455f), Vector3.up, 20 * Time.deltaTime);
        transform.RotateAround(pivot.transform.position, pivot.transform.up, 10 * Time.deltaTime);

        yield return new WaitForSeconds(5);
        ffloat = false;
    }
    //To keep player from falling off rotating platforms, set it as a parent of the obstacle

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Player") {
            col.gameObject.transform.parent = gameObject.transform;
        }
    }
 
    //got rid of this because it basically turns the player into a piece of paper in the wind :(
    //added a line in teleportpadmove to help set the parent of the player back to null
    //void OnCollisionExit(Collision col) {
    //    if (col.gameObject.tag == "Player") {
    //        col.gameObject.transform.parent = null;
    //   }
    //}

  
   
}
