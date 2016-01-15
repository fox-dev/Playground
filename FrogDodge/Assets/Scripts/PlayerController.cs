using UnityEngine;
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
        }

        else if(Input.GetKeyDown("left") && left)
        {
            GetComponent<Collider>().enabled = false;
            inside = false;
            left = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            anim.SetTrigger(moveHash);
        }
        else if (Input.GetKeyDown("right") && right)
        {
            GetComponent<Collider>().enabled = false;
            inside = false;
            right = false;
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
            anim.SetTrigger(moveHash);
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

   

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube" || other.tag == "Sphere")
        {
            if (other.transform.position.x < transform.position.x || other.transform.position.x > transform.position.x)
            {
                inside = false;
                left = false;
                right = false;
               
            }
            
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Cube" || other.tag == "Sphere")
        {

            if (other.transform.position.x > transform.position.x && other.GetComponent<Rigidbody>().velocity.x >= 0f)
            {
                //do nothing if object is moving to the right away from player
            }
            else if(other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
            {
                //do nothing if object is moving to the left away from player
            }
            else if (other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
            {
                //do nothing if object is moving to the left away from player
            }
            else if (other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x >= 0f)
            {
                //object is moving towards player from the left
                left = true;
                inside = true;

            }
            else if (other.transform.position.x > transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
            {
                //object is moving towards player from the right
                right = true;
                inside = true;


            }




        }
    }
}
