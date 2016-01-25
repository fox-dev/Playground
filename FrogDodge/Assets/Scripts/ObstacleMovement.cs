using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour 
{

    
    public float moveSpeed;
    public float maxSpeed;

    public Vector3 startPos;
    public Quaternion startRot;

	private GameController gameController;

    private PlayerController frog;
  

    void Start()
    {
        moveSpeed = 0;
        startPos = transform.position;
        startRot = transform.rotation;

        GameObject pc = GameObject.FindWithTag("Player");

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

        if (pc != null)
        {
            frog = pc.GetComponent<PlayerController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'PlayertController' script");
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
	void Update () {

        

        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * moveSpeed);

        }

	}

    void OnDisable()
    {
        Reset();
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
        frog.GetComponent<MeshRenderer>().enabled = false;
        Renderer[] renderers = frog.GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }
    }
 
}
