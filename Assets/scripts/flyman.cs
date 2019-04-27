using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyman : MonoBehaviour {

    public Transform target;//set target from inspector instead of looking in Update
    public float vel = 3f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //rotate to look at the player
        //transform.LookAt(target.position);
        //transform.Rotate(new Vector3(0, 90, 0), Space.Self);//correcting the original rotation

        //se o player estiver antes do inimigo (eixo x)
        if (target.position.x <= transform.position.x)
        {  
            
            //Seguir o player
            transform.position = Vector3.MoveTowards(transform.position, target.position, vel * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector3(-vel * Time.deltaTime, Random.Range(-1, 1) * Time.deltaTime, 0));

        }
    }
}
