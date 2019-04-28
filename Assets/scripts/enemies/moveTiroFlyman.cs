using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTiroFlyman : MonoBehaviour {

    private float vel = 10;

    bool direcao;
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");

        if(transform.position.x < player.transform.position.x)
        {
            direcao = true;
        } else if(transform.position.x > player.transform.position.x)
        {
            direcao = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(direcao)
        {
            transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));
        }
        else
        {
            transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));
        }


        //Destruir
        if (transform.position.x <= -10 || transform.position.x >= 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
