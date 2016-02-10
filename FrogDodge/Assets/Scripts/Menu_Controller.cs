using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Controller : MonoBehaviour
{


    BGM audioManager;

    // Use this for initialization
    void Start()
    {
       

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
    void Update()
    {

        
    }




}
