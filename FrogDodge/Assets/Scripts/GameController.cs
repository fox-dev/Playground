using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject scoreText;
	//public GameObject restartText;
	public GameObject gameOverText;
	public GameObject player;
    

	private int score, highscore;
	private bool gameOver;
	private bool restart;
    private Button restartButton, menuButton;

    BGM audioManager;

    public Transform centerPoint, lowerCenterPoint;
    float lerpValue = 0.05f;
    float currentTime = 0f;

   

    // Use this for initialization
    void Start () {
        if(PlayerPrefs.GetInt("highscore") != null)
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }

		score = 0;
		UpdateScore ();
		restart = false;
       
       // restartText.GetComponent<Text>().text = "";

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
        //Instantiate (player, position , Quaternion.identity);

        restartButton = GameObject.FindGameObjectWithTag("Restart_Button").GetComponent<Button>();
        restartButton.gameObject.SetActive(false);

        menuButton = GameObject.FindGameObjectWithTag("Menu_Button").GetComponent<Button>();
        menuButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () 
	{

        print(highscore + " " + PlayerPrefs.GetString("highscore"));
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("highscore", 0);
        }
            if (restart)
		{
			if(Input.GetKeyDown(KeyCode.R)) //|| (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))

			{
				SceneManager.LoadScene ("NewMain");
			}
		}
	}

    void FixedUpdate()
    {
        if (gameOver)
        {
            gameOverStuff();
        }
        else
        {
            currentTime = Time.time;
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
    
    public void	gameOverStuff()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        restart = true;
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
        //print(Time.time - currentTime);
        if ((Time.time - currentTime) > 0.3f)
        {
            lerpButtons();
        }
    }

    public bool gameEnded()
    {
        return gameOver;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }


    public void lerpButtons()
    {
        restartButton.transform.position = Vector3.Lerp(restartButton.transform.position, centerPoint.transform.position, lerpValue);
        menuButton.transform.position = Vector3.Lerp(menuButton.transform.position, lowerCenterPoint.transform.position, lerpValue);
    }



}
