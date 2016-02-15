using UnityEngine;
using System.Collections;

public class Highscore_Label : MonoBehaviour {

	// Use this for initialization
	void Start () {

       
        GetComponent<TextMesh>().text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();


        transform.position = new Vector3(-60, 2, PlayerPrefs.GetInt("highscore")*11 - 3f);

    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
