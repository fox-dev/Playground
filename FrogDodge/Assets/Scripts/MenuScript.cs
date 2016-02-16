using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button play, highscore;
    public Button reset;
    private bool openCanvas, openTCanvas;
    

    public Canvas highScore_Canvas;
    public GameObject highscoreText;
    public Transform canvasPos_on, canvasPos_off;

	public Canvas tutorial_Canvas;
	public Transform canvasPosT_on, canvasPosT_off;

    public GameObject confirmPanel;

    public GameObject frog;
    

    float lerpValue = 0.5f;

    void Start()
    {
        openCanvas = false;
        play = play.GetComponent<Button>();
        confirmPanel.gameObject.SetActive(false);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void confirmClearScore()
    {
        confirmPanel.SetActive(true);
        reset.gameObject.SetActive(false);
    }

    public void closeConfirmClearScore()
    {
        confirmPanel.SetActive(false);
        reset.gameObject.SetActive(true);
        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            reset.gameObject.SetActive(false);
        }
    }

    public void resetScore()
    {
        PlayerPrefs.SetInt("highscore", 0);
        highscoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
        reset.gameObject.SetActive(true);
        confirmPanel.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            reset.gameObject.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        
        lerpCanvases();

        frog.GetComponent<Transform>().Rotate(Vector3.up, 0.5f);
        
    }

    public void lerpCanvases()
    {
        if(openCanvas)
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, canvasPos_on.position, lerpValue);
        }
        else
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, canvasPos_off.position, lerpValue);
        }

		if(openTCanvas)
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas.transform.position, canvasPosT_on.position, lerpValue);
		}
		else
		{
			tutorial_Canvas.transform.position = Vector3.Lerp(tutorial_Canvas.transform.position, canvasPosT_off.position, lerpValue);
		}
			

        
    }

    public void openHighScoresCanvas()
    {
        highscoreText.GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();

        if (PlayerPrefs.GetInt("highscore") == 0)
        {
            reset.gameObject.SetActive(false);
        }

        if (openCanvas == true)
        {
            openCanvas = false;
        }
        else
        {
            openCanvas = true;
        }
    }

	public void openTutorialCanvas()
	{

		if (openTCanvas == true)
		{
			openTCanvas = false;
		}
		else
		{
			openTCanvas = true;
		}
	}

	public void closeTutorialCanvas()
	{
		if (openTCanvas == true) {
			openTCanvas = false;
		}
	}


    
}
