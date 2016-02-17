using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Play();
	
	}

    void Awake()
    {
        Destroy(this.gameObject, 5f); //destroy after 5 seconds.
    }

    
	
}
