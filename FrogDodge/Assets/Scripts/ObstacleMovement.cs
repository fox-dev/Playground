﻿using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour 
{

    public GameObject explosion;

    public float moveSpeed;
    public float maxSpeed;
	private float acceleration;
	public float velocity;

    public Vector3 startPos;
    public Quaternion startRot;

	private GameController gameController;

    private PlayerController frog;
  

    void Start()
    {
        
        //To 0 velocity all obstacles till player reaches trigger
        moveSpeed = 0;
		acceleration = 5;
        
        startPos = transform.position;
        startRot = transform.rotation;

        GameObject pc = GameObject.FindWithTag("Player");

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        if (pc != null)
        {
            frog = pc.GetComponent<PlayerController>();
        }
        if (frog == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }



        if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if(gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}

    }

	
	// Update is called once per frame
	void FixedUpdate () {

        
		//accelerates the obstacle when in ready state until obstacle reaches max speed.
		if (moveSpeed < maxSpeed && GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            //GetComponent<Rigidbody>().AddForce(new Vector3(acceleration, 0, 0) * moveSpeed );
			moveSpeed += acceleration; 
			if (GetComponent<Rigidbody> ().velocity.x > 0) {
				GetComponent<Rigidbody> ().velocity = new Vector3 (moveSpeed, 0, 0);
			} else {
				GetComponent<Rigidbody> ().velocity = new Vector3 (-moveSpeed, 0, 0);
			}
        }

		velocity = GetComponent<Rigidbody> ().velocity.magnitude;
	}

    void OnDisable()
    {
        Reset();

    }

    void OnEnable()
    {
        
        
    }

    void Reset()
    {
        //print("RESET");
        transform.position = new Vector3(startPos.x, startPos.y, transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(startRot.x, startRot.y, startRot.z));

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

		moveSpeed = 0;
    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "PlayerMoveBox") 
		{
            

            if (other.transform.position.x > transform.position.x && GetComponent<Rigidbody>().velocity.x >= 0f)
            {
                frog.insideLeft();
            }
            else if(other.transform.position.x < transform.position.x && GetComponent<Rigidbody>().velocity.x <= 0f)
            {
                frog.insideRight();
            }
		}

        if (other.tag == "Player")
        {
            destroyPlayer();
            gameController.GameOver();
        }
	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerMoveBox")
        {

            if (other.transform.position.x > transform.position.x && GetComponent<Rigidbody>().velocity.x >= 0f)
            {
                frog.objectExitLeft();
            }
            else if (other.transform.position.x < transform.position.x && GetComponent<Rigidbody>().velocity.x <= 0f)
            {
                frog.objectExitRight();
            }


        }
    }

    void OnCollisionEnter(Collision collision) //physical contact
    {
       
        if (collision.collider.tag == "Cube")
        {
            Instantiate(Resources.Load("explosion"), collision.contacts[0].point, Quaternion.identity);
            collision.collider.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }

    void destroyPlayer()
    {
        //frog.gameObject.SetActive(false);

        /*
        Renderer[] renderers = frog.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
        */
        frog.playDead();
    }
 
}