using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTiroGreen : MonoBehaviour {

    private Transform target;//set target from inspector instead of looking in Update

    public GameObject player;

    public float vel = 5f;

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        target = player.transform;

        move();
        destruir();
    }

    void move()
    {
        //Seguir o player
        transform.position = Vector3.MoveTowards(transform.position, target.position, vel * Time.deltaTime);
    }

    void destruir()
    {
        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("avela"))
        {
            Destroy(this.gameObject);
        }
    }
}
