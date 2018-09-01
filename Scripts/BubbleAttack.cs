using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAttack : MonoBehaviour {
    public GameObject bubble;
    public Camera camera;
    public GameObject bubblespawn;
    Vector3 campos;
   
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        GameObject shoot;
        //0 is the primary button
        campos = camera.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
           // shoot = Instantiate(bubble, campos, Quaternion.identity);
            shoot = Instantiate(bubble,bubblespawn.transform.position, Quaternion.identity);
            shoot.GetComponent<Rigidbody>().AddForce(transform.forward * 200);
            shoot.GetComponent<Rigidbody>().AddForce(transform.up * 50);

            if(Physics.Raycast(camera.transform.position,camera.transform.forward,out hit, 5))
            {
                if (hit.collider.tag == "monster")
                {
                    print("bubble has hit monster");
                }

                else
                {

                    
                    //causes bubble to float upward slowly
            
                   
                    
                }
               
            }

            Destroy(shoot, 20);
            
        }
	}
}
