﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    private Vector3 followPos;
    public float width, height;

	// Use this for initialization
	void Start () {

        //Camera.main.aspect = width / height;
	
	}
	
	// Update is called once per frame
	void Update () {
        //Camera.main.aspect = width / height;
        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 36.9528f);
        //transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 81);
        Vector3 follow = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 76f); 
        followPos = Vector3.Lerp(transform.position, follow, Time.deltaTime);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, followPos.z);

    }
}
