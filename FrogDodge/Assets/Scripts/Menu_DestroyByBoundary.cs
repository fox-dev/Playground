using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Menu_DestroyByBoundary : MonoBehaviour
{

    Rigidbody rg;
    public GameObject player;
    public GameObject backRoad;
    public GameObject[] roads;
    public List<GameObject> disabledRoads;



    void Start()
    {
        disabledRoads = new List<GameObject>();
    }



    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Road")
        {
            backRoad = other.gameObject;
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 50);

            if (other.name == "Road 1")
            {

                //Move the obstacles on that road when the road moves
                //Instantiate(obstacle, new Vector3(frontRoad.transform.position.x - 8f, 0.525f, frontRoad.transform.position.z), Quaternion.identity);
                // obstacleCube.transform.position = new Vector3(obstacleCube.transform.position.x, obstacleCube.transform.position.y, roads[0].transform.position.z);
            }
            // if(other.name == "Road 2")
            {
                // obstacleSphere.transform.position = new Vector3(obstacleSphere.transform.position.x, obstacleSphere.transform.position.y, roads[1].transform.position.z);
            }

        }

    }
}
