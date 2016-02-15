using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button play, highscore;
    public Button reset;
    private bool openCanvas;
    

    public Canvas highScore_Canvas;
    public GameObject highscoreText;
    public Transform canvasPos_on, canvasPos_off;

    public GameObject confirmPanel;
    

    float lerpValue = 0.05f;

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


    void Update()
    {
        
        lerpHighScores();
        
    }

    public void lerpHighScores()
    {
        if(openCanvas)
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, canvasPos_on.position, lerpValue);
        }
        else
        {
            highScore_Canvas.transform.position = Vector3.Lerp(highScore_Canvas.transform.position, canvasPos_off.position, lerpValue);
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


    
}
