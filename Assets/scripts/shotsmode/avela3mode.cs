using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avela3mode : MonoBehaviour {

    public float vel = 1f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));

        //Destruir
        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
