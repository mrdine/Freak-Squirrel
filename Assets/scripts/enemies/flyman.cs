using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyman : MonoBehaviour {

    private Transform target;//set target from inspector instead of looking in Update

    public GameObject player;

    public float vel = 3f;

    public GameObject bala;

    //Para tempo do tiro
    public float fireRate = 1f;
    private float nextFire;

    private float vida = 3;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {

        target = player.transform;
        
        moveFlyman();


        atirar();


        //Destruir
        destruir();
    }

     void moveFlyman()
    {
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

    void atirar()
    {
        //Tiro padrão
        if (Time.time > nextFire && transform.position.x <= 10)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bala, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
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

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("avela"))
        {
            vida = vida - 1;
        }
    }
}
