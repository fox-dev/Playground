using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    bool inside;
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
        print(inside);
        //print(endRotation.transform.rotation.x);

        //float moveHorizontal = Input.GetAxis("Horizontal");   
        //float moveVertical = Input.GetAxis("Vertical");

        lerp += Time.deltaTime / duration;
     

        if(inside) { 
            if (Input.GetKeyDown("space"))
            {
                endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
                transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);
    
                anim.SetTrigger(moveHash);
            }
            else
            {
                anim.SetTrigger(stopHash);
            }
        }
        else
        {
            anim.SetTrigger(stopHash);
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
            inside = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Cube" || other.tag == "Sphere")
        {

            if (other.transform.position.x > transform.position.x && other.GetComponent<Rigidbody>().velocity.x >= 0f)
            {
                //do nothing
            }
            else
            {
                inside = true;
            }

            
            
            
        }
    }
}
