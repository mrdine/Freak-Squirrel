using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnEnemies : MonoBehaviour {

    public GameObject flyman;
    public GameObject torpedo;
    public GameObject greenAlien;

    public Text uiScore;

    public GameObject avela3mode;

    // Use this for initialization
    void Start () {

        Invoke("spawnTorpedo", 0.5f);
        Invoke("spawnFlyman", 0.5f);
        Invoke("spawnGreenAlien", 0.5f);

        Invoke("spawnmode3avela", 0.5f);
	}
	
	// Update is called once per frame
	void Update () {


    }

    private void spawnTorpedo()
    {
        float randomTime = Random.Range(1, 3);

        Vector3 position = new Vector3(Random.Range(13, 22), Random.Range(-2f, 4f), 0.5f);
        Instantiate(torpedo, position, Quaternion.identity);


        Invoke("spawnTorpedo", randomTime);
    }

    private void spawnFlyman()
    {
        float randomTime = Random.Range(3, 5);

        Vector3 position = new Vector3(Random.Range(13, 26), Random.Range(-2f, 4f), 0.5f);
        Instantiate(flyman, position, Quaternion.identity);


        Invoke("spawnFlyman", randomTime);
    }

    private void spawnGreenAlien()
    {
        float randomTime = Random.Range(7, 25);
        if (int.Parse(uiScore.text) >= 25)
        { 
            Vector3 position = new Vector3(Random.Range(13, 26), Random.Range(-2f, 4f), 0.5f);
            Instantiate(greenAlien, position, Quaternion.identity);
        }
        Invoke("spawnGreenAlien", randomTime);
    }

    // modos de tiro

    private void spawnmode3avela()
    {
        float randomTime = 30;
        if (int.Parse(uiScore.text) >= 10)
        {
            Vector3 position = new Vector3(Random.Range(13, 22), Random.Range(-2f, 4f), 0.5f);
            Instantiate(avela3mode, position, Quaternion.identity);
        }
        Invoke("spawnmode3avela", randomTime);
    }
}
