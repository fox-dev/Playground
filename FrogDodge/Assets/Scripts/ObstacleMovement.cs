using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour 
{

    
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
		acceleration = 10;
        
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
		if (GetComponent<Rigidbody>().velocity.magnitude <= maxSpeed && GetComponent<Rigidbody>().velocity.magnitude != 0)
        {
            //GetComponent<Rigidbody>().AddForce(new Vector3(acceleration, 0, 0) * moveSpeed );
			moveSpeed = 40; 
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
        //Reset();
        
    }

    void Reset()
    {
        //print("RESET");
        transform.position = new Vector3(startPos.x, startPos.y, transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(startRot.x, startRot.y, startRot.z));

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
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
	}

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
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

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            destroyPlayer();
            gameController.GameOver();
        }
     
    }

    void destroyPlayer()
    {
        //frog.gameObject.SetActive(false);
        //frog.GetComponent<MeshRenderer>().enabled = false;
        Renderer[] renderers = frog.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
    }
 
}
