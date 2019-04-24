using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private float vel = 5f;
    private float fall = 0f;


	// Use this for initialization
	void Start () {
        fall = 0f;
	}
	
	// Update is called once per frame
	void Update () {


        //Gravidade
        transform.Translate(new Vector3(0, fall * Time.fixedDeltaTime, 0));
        fall -= 0.02f;
        //Entradas do teclado para controlar o personagem
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, vel * Time.fixedDeltaTime, 0));
            fall += 1f;
            vel -= 0.5f;
            if(fall >= 0)
            {
                fall = 0;
            }
        }

        if(fall <= 0.08f)
        {
            vel = 5f;
        }
    }
}
