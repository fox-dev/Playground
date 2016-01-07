using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rg;
    public float speed = 0.1f;
    Vector3 dest;

    void Start()
    {
        dest = new Vector3(transform.position.x, 0.525f, transform.position.z);
    }

    void Update()
	{
        

        //float moveHorizontal = Input.GetAxis("Horizontal");   
        float moveVertical = Input.GetAxis("Vertical");
        float step = speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            dest = new Vector3(transform.position.x, 0.525f, transform.position.z + 3);
        }

        transform.position = Vector3.Lerp(transform.position, dest, step);

        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        //Vector3 movement = new Vector3(0.0f, 0.0f, 1f);

        //rg.velocity = movement * speed;



    }
}
