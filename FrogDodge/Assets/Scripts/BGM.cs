using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

    public AudioClip bgm, gameOver;

    private GameController gameController;

    // Use this for initialization
    void Start () {
        

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void GameOverMusic()
    {
        GetComponent<AudioSource>().clip = gameOver;
        GetComponent<AudioSource>().Play();
    }
}
