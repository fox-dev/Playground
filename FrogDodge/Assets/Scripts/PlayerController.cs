﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    bool inside,left,right;
    ArrayList obstacles;


	Rigidbody rg;
    Vector3 startPos, endPos;
    Quaternion startRot, endRot;

    private GameObject endRotation;

    private float lerp = 0, duration = 5f;
    public float speed, rotSpeed, moveDistance;
    public int rotationInDegrees;

    Animator anim;
	private GameController gameController;
	public int scoreValue;

    int moveHash = Animator.StringToHash("Roll");
    int stopHash = Animator.StringToHash("Stop");

    void Start()
    {
        inside = false;
        obstacles = new ArrayList();
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       
        startRot = transform.rotation;
        endRotation = new GameObject();
        endRotation.transform.rotation = transform.rotation;

        anim = GetComponent<Animator>();

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

    }

    void Update()
	{
        //print(inside);
        //print(endRotation.transform.rotation.x);

        //float moveHorizontal = Input.GetAxis("Horizontal");   
        //float moveVertical = Input.GetAxis("Vertical");

        lerp += Time.deltaTime / duration;

       
        if(Input.GetKeyDown("space"))
        {

            GetComponent<Collider>().enabled = false;
            inside = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            anim.SetTrigger(moveHash);
			gameController.addScore(scoreValue);
        }

        else if(Input.GetKeyDown("left") && left)
        {
            GetComponent<Collider>().enabled = false;
            inside = false;
            left = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            anim.SetTrigger(moveHash);
			gameController.addScore(scoreValue);
        }
        else if (Input.GetKeyDown("right") && right)
        {
            GetComponent<Collider>().enabled = false;
            inside = false;
            right = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            anim.SetTrigger(moveHash);
			gameController.addScore(scoreValue);
        }
        else
        {
            anim.SetTrigger(stopHash);
        }

        if(transform.position.z >= endPos.z)
        {
            GetComponent<Collider>().enabled = true;
        }
      

        //float move = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed", move);

        transform.position = Vector3.MoveTowards(transform.position, endPos, speed*Time.deltaTime);

        //transform.rotation = Quaternion.Lerp(transform.rotation, endRotation.transform.rotation, rotSpeed * Time.deltaTime);

        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        //Vector3 movement = new Vector3(0.0f, 0.0f, 1f);

        //rg.velocity = movement * speed;
    }

	public void insideLeft()
	{
		inside = true;
		left = true;
	}

	public void insideRight()
	{
		inside = true;
		right = true;
	}

	public void objectExit()
	{
		inside = false;
		left = false;
		right = false;
	}
}
