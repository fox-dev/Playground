using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rg;
	public float speed;

	void FixedUpdate()
	{
		//float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
       //Vector3 movement = new Vector3(0.0f, 0.0f, 1f);


        rg = GetComponent<Rigidbody>();
		rg.velocity = movement * speed;
        print(rg.velocity.z);

	}
}
