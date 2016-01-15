using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public Canvas menu;
    public Button play;

    void Start()
    {
        menu = menu.GetComponent<Canvas>();
        play = play.GetComponent<Button>();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
