using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject scoreText;
	public GameObject restartText;
	public GameObject gameOverText;
	public GameObject player;

	private int score;
	private bool gameOver;
	private bool restart;

    BGM audioManager;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
		restart = false;
       
        restartText.GetComponent<Text>().text = "";

        gameOverText.GetComponent<Text>().text = "";

        GameObject audioObject = GameObject.FindWithTag("Audio");

        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<BGM>();
        }
        if (audioManager == null)
        {
            Debug.Log("Cannot find 'BGM' script");
        }

		Vector3 position = new Vector3(0, 0, 0);
		Instantiate (player, position , Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () 
	{
       
        if (gameOver) {
    
            restartText.GetComponent<Text>().text = "Tap to Restart";
            restart = true;
		}

		if(restart)
		{
			if(Input.GetKeyDown(KeyCode.R) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))

			{
				SceneManager.LoadScene ("NewMain");
			}
		}
	}

	void UpdateScore()
	{
        
        scoreText.GetComponent<Text>().text = "Score : " + score;

    }

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver()
	{
        gameOverText.GetComponent<Text>().text = "Game Over"; ;
        audioManager.GameOverMusic();
		gameOver = true;
	}	

    public bool gameEnded()
    {
        return gameOver;
    }


}
