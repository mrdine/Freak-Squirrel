using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour {

    public int pontos;
    public bool gameOver = false;
    public GameObject gameOverMenuUi;
    public Text Tpontos;
	// Update is called once per frame
	void Update ()
    {
		if(gameOver)
        {
            pause();
        }
	}

    void pause()
    {
        Tpontos.text = "" + pontos;
        gameOverMenuUi.SetActive(true);
        Time.timeScale = 0f;
    }

    public void tryAgain()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("gameplay");
        StartCoroutine(LoadYourAsyncScene("gameplay"));
    }

    public void loadGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("mainMenu");
        StartCoroutine(LoadYourAsyncScene("mainMenu"));
    }
    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadYourAsyncScene(string cena)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(cena);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
