using UnityEngine;
using System.Collections;

public class RoadObstacleSpawner : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        // Instantiate(obstacle, new Vector3(transform.position.x - 8f, 0.525f, transform.position.z), Quaternion.identity);


        Rigidbody[] obstacles = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in obstacles)
        {
            r.velocity = Vector3.zero;
            r.angularVelocity = Vector3.zero;
        }
    }

    // On entering collider of next road, 
	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody[] obstacles = GetComponentsInChildren<Rigidbody>();

            foreach (Rigidbody r in obstacles)
            {
                /*if (r.tag == "Cube")
                {
                    r.velocity = new Vector3(30, 0, 0);

                }

                if (r.tag == "Sphere")
                {
                    r.velocity = new Vector3(-30, 0, 0);
                }*/

				r.velocity = new Vector3 (1, 0, 0); // Sets obstacles into ready state to be moved.
 
               
            }

        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Cube")
        {
            if(other.GetComponent<Rigidbody>().velocity.x > 0)
            {
                other.transform.position = new Vector3(-(GetComponent<BoxCollider>().size.x/2 - other.GetComponent<BoxCollider>().size.x/2) - other.GetComponent<BoxCollider>().size.x, 1, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(20, 0, other.transform.position.z);
            }
        }
        else if(other.tag == "Sphere")
        {
            if (other.GetComponent<Rigidbody>().velocity.x > 0)
            {
                other.transform.position = new Vector3(-(GetComponent<BoxCollider>().size.x / 2 - other.GetComponent<BoxCollider>().size.x / 2) - other.GetComponent<BoxCollider>().size.x, 1, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3((GetComponent<BoxCollider>().size.x/2 + other.GetComponent<BoxCollider>().size.x/2),0, other.transform.position.z);
            }
        }

    }
}
