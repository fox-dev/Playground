using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public int inside,left,right = 0;
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

    //int moveHash = Animator.StringToHash("Roll");
    //int stopHash = Animator.StringToHash("Stop");
    int moveHash = Animator.StringToHash("Jump");
    int stopHash = Animator.StringToHash("Idle");

    void Start()
    {
        inside = 0;
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
        //print(endPos.z);
        //print(inside + " " + left + " " + right);
        //print(endRotation.transform.rotation.x);

        //float moveHorizontal = Input.GetAxis("Horizontal");   
        //float moveVertical = Input.GetAxis("Vertical");

        lerp += Time.deltaTime / duration;

        

        if (Input.touchCount > 0)
        {
            float touched = Input.GetTouch(0).position.x;
            print(touched);
        }

        


        if ((Input.GetKeyDown("space")) && endPos.z == transform.position.z)
        {

            //GetComponent<Collider>().enabled = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            GetComponent<AudioSource>().Play();
            anim.SetTrigger(moveHash);
			gameController.addScore(scoreValue);
        }

        else if((Input.GetKeyDown("left" ) || (Input.touchCount > 0 && Input.GetTouch(0).position.x < Screen.width/2 && Input.GetTouch(0).phase == TouchPhase.Began))  && left > 0 && endPos.z == transform.position.z)
        {
            //GetComponent<Collider>().enabled = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            GetComponent<AudioSource>().Play();
            anim.SetTrigger(moveHash);
			gameController.addScore(scoreValue);
        }
        else if ((Input.GetKeyDown("right") || (Input.touchCount > 0 && Input.GetTouch(0).position.x > Screen.width / 2 && Input.GetTouch(0).phase == TouchPhase.Began)) && right > 0 && endPos.z == transform.position.z)
        {
            //GetComponent<Collider>().enabled = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            GetComponent<AudioSource>().Play();
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
		inside++;
		left++;
	}

	public void insideRight()
	{
		inside++;
		right++;
	}

    public void objectExitLeft()
    {
        inside--;
        left--;

    }

    public void objectExitRight()
    {
        inside--;
        right--;

    }

  

}
