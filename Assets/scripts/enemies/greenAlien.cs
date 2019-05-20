using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenAlien : MonoBehaviour {


    //tempo do tiro
    public float fireRate;
    private float nextFire;

    private float vida = 5;
    private float vel = 2f;

    public GameObject player;

    private Transform target;

    //bala
    public GameObject bala;
    bool podeatirar = true;

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("Player");

        nextFire = 10f;

	}
	
	// Update is called once per frame
	void Update () {

        target = player.transform;

        move();

        atirar();

        destruir();


	}

    void move()
    {
        if (transform.position.x >= 4f)
        {
            //Seguir o player
            transform.position = Vector3.MoveTowards(transform.position, target.position, vel * Time.deltaTime);
        }
    }

    void atirar()
    {
        //Tiro padrão
        if (podeatirar && transform.position.x <= 10)
        {
            //nextFire = Time.time + fireRate;
            podeatirar = false;
            Instantiate(bala, new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), transform.rotation);
            //movimento da bala num script separado
        }
    }

    void destruir()
    {
        if (transform.position.x <= -10 || vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if( other.gameObject.CompareTag("avela") )
        {
            vida = vida - 1;
            podeatirar = true;
        }
    }
}
