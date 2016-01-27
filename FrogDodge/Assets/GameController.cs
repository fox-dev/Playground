using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

    BGM audioManager;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

        GameObject audioObject = GameObject.FindWithTag("Audio");

        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<BGM>();
        }
        if (audioManager == null)
        {
            Debug.Log("Cannot find 'BGM' script");
        }

    }
	
	// Update is called once per frame
	void Update () 
	{
		if (gameOver) {
			restartText.text = "Press 'R' to Restart";
			restart = true;
		}

		if(restart)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				SceneManager.LoadScene ("NewMain");
			}
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score " + score;
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
        audioManager.GameOverMusic();
		gameOver = true;
	}	

    public bool gameEnded()
    {
        return gameOver;
    }


}
