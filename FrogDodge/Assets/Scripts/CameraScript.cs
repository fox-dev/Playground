using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(player.transform.position.x + 10f, player.transform.position.y + 15f, player.transform.position.z - 10f);
	
	}
}
