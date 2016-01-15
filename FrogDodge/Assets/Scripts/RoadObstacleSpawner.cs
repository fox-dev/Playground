using UnityEngine;
using System.Collections;

public class RoadObstacleSpawner : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        
       // Instantiate(obstacle, new Vector3(transform.position.x - 8f, 0.525f, transform.position.z), Quaternion.identity);
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Cube")
        {
            if(other.GetComponent<Rigidbody>().velocity.x > 0)
            {
                other.transform.position = new Vector3(-20, 0, other.transform.position.z);
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
                other.transform.position = new Vector3(-20, 0, other.transform.position.z);
            }
            else
            {
                other.transform.position = new Vector3(20, 0, other.transform.position.z);
            }
        }

    }
}
