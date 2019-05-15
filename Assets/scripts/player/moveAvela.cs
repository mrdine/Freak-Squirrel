using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveAvela : MonoBehaviour {

    public float vel = 10f;

    private GameObject Player;
    private player pScript;
    int pontos;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindWithTag("Player");
        pScript = Player.GetComponent<player>();
    }
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));

        //Destruir
        if (transform.position.x >= 12)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D outro)
    {
        if(outro.gameObject.CompareTag("enemy"))
        {
            pontos = pScript.pontos + 1;
            pScript.pontos = pontos;
            Destroy(this.gameObject);
        }
    }

}
