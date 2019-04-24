﻿using System.Collections;
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

        var distanceZ = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).x;

        var righBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceZ)).x;

        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceZ)).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distanceZ)).y;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, righBorder), Mathf.Clamp(transform.position.y, topBorder, bottomBorder), transform.position.z);

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
