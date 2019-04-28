using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torpedo : MonoBehaviour {

    public float vel = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));

        //Destruir
        if(transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
	}

}
