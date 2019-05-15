using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}

    public void play()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void loadRank()
    {
        //abrir janela do rank
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
