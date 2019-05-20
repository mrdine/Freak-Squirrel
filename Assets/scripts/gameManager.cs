using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    public GameObject Player;
    public Image imageCanvas;
    public Text textCanvas;
    
    public GameObject canvas;
    private gameOverMenu gomScript;

    public Sprite heart1;
    public Sprite heart2;
    public Sprite heart3;
    public Sprite heart4;
    public Sprite heart5;


    private player playerScript;
    private int pontos;

    // Use this for initialization
    void Start () {
        playerScript = Player.GetComponent<player>();
        pontos = 0;
        
	}
	
	// Update is called once per frame
	void Update () {

        if(playerScript.vida <= 0)
        {
            gameOver();
        }

        updateVida();

        gomScript = canvas.GetComponent<gameOverMenu>();

    }

    void gameOver()
    {

        pontos = playerScript.pontos;
        gomScript.pontos = pontos;
        gomScript.gameOver = true;

    }

    void updateVida()
    {
        if(playerScript.vida == 5)
        {
            imageCanvas.sprite = heart5;
        }
        else if(playerScript.vida == 4)
        {
            imageCanvas.sprite = heart4;
        }
        else if(playerScript.vida == 3)
        {
            imageCanvas.sprite = heart3;
        }
        else if(playerScript.vida == 2)
        {
            imageCanvas.sprite = heart2;
        }

        else if (playerScript.vida == 1)
        {
            imageCanvas.sprite = heart1;
        }
    }

    void updatePontos()
    {
        textCanvas.text = "" + pontos;
    }
}
