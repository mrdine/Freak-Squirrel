using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    private float vel = 5f;
    private float fall = 0f;

    //Vida
    public int vida;
    //Pontos
    public int pontos;

    public GameObject avela;
    public Text textCanvas;
    //Para tempo do tiro
    public float fireRate = 0.4f;
    private float nextFire;

    //modo de tiro
    string tiroMode;

    // Use this for initialization
    void Start () {
        fall = 0f;
        vida = 5;
        tiroMode = "padrao";
        pontos = 0;
	}
	
	// Update is called once per frame
	void Update () {

        //Para evitar que o player saia dos limites da camera

        var distanceZ = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;

        var righBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;

        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, righBorder), Mathf.Clamp(transform.position.y, topBorder + 0.5f, bottomBorder), transform.position.z);
        /////////////////////////////////////////////
        //Gravidade
        /*
        transform.Translate(new Vector3(0, fall * Time.fixedDeltaTime, 0));
        fall -= 0.02f;
        */

        movePlayer();
        atirar();

        //atualiza pontos (Quand um avela acerta um inimigo é somado 1 aos pontos, aqui serve para atualizar no Canvas)
        textCanvas.text = "" + pontos;
    }

    void movePlayer()
    {
        //Entradas do teclado para controlar o personagem
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, vel * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -vel * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));
        }
    }


    void atirar()
    {
        //Tiro padrão
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {   
            if(tiroMode == "padrao")
            {
                nextFire = Time.time + fireRate;
                Instantiate(avela, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.25f, transform.position.z), transform.rotation);
            }
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("tiroInimigo") || other.gameObject.CompareTag("enemy"))
        {
            vida--;
        }

        else if(other.gameObject.CompareTag("vidaExtra"))
        {
            if(vida < 5)
            {
                vida++;
            }
        }
    }
}


