using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rg;
    Vector3 startPos, endPos;
    Quaternion startRot, endRot;

    private GameObject endRotation;

    private float lerp = 0, duration = 5f;
    public float speed, rotSpeed, moveDistance;
    public int rotationInDegrees;

    //Animator anim;

    //int moveHash = Animator.StringToHash("Move");

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
       
        startRot = transform.rotation;

        endRotation = new GameObject();
        endRotation.transform.rotation = transform.rotation;

       // anim = GetComponent<Animator>();
      



    }

    void Update()
	{
        print(endRotation.transform.rotation.x);

        //float moveHorizontal = Input.GetAxis("Horizontal");   
        //float moveVertical = Input.GetAxis("Vertical");

        lerp += Time.deltaTime / duration;
     

        if (Input.GetKeyDown("space"))
        {
            endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
            endRotation.transform.rotation *= Quaternion.Euler(rotationInDegrees, 0, 0);

            //anim.SetTrigger(moveHash);
           
          
        }

       // float move = Input.GetAxis("Vertical");
       // anim.SetFloat("Speed", move);

        transform.position = Vector3.MoveTowards(transform.position, endPos, speed*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, endRotation.transform.rotation, rotSpeed * Time.deltaTime);

        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        //Vector3 movement = new Vector3(0.0f, 0.0f, 1f);

        //rg.velocity = movement * speed;



    }
}
