using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

    
    public float moveSpeed;
    public float maxSpeed;

	
	// Update is called once per frame
	void Update () {

        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * moveSpeed);

        }

	}
}
