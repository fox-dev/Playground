using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {

    
    public float moveSpeed;
    public float maxSpeed;

    public Vector3 startPos;
    public Quaternion startRot;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;

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
        print("RESET");
        transform.position = new Vector3(startPos.x, startPos.y, transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(startRot.x, startRot.y, startRot.z));

        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

 
}
