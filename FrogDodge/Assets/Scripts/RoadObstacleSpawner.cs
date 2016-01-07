using UnityEngine;
using System.Collections;

public class RoadObstacleSpawner : MonoBehaviour {

    public GameObject[] roads;

    // Use this for initialization
    void Start()
    {
        
       // Instantiate(obstacle, new Vector3(transform.position.x - 8f, 0.525f, transform.position.z), Quaternion.identity);
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Cube")
        {
            other.transform.position = new Vector3(-10, 0.525f, other.transform.position.z);
        }
        
        else if(other.tag == "Sphere")
        {
            other.transform.position = new Vector3(-10, 0.525f, other.transform.position.z);
        }

    }
}
