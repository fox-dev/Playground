using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	Rigidbody rg;
    public GameObject player;
    public GameObject frontRoad;
	public GameObject frontRoadR;
	public GameObject frontRoadL;
    public GameObject[] roads;
	public GameObject[] roadsR;
	public GameObject[] roadsL;

    public GameObject obstacleCube, obstacleSphere;

	void OnTriggerExit(Collider other)
	{
        if (other.tag == "Road")
        {
            frontRoad = other.gameObject;
            other.transform.position = new Vector3(0, 0, other.transform.position.z + 40);
            if (other.name == "Road1")
            {
               
                //Move the obstacles on that road when the road moves
                //Instantiate(obstacle, new Vector3(frontRoad.transform.position.x - 8f, 0.525f, frontRoad.transform.position.z), Quaternion.identity);
                obstacleCube.transform.position = new Vector3(obstacleCube.transform.position.x -3f, 0.525f, roads[0].transform.position.z);
            }
            if(other.name == "Road2")
            {
                obstacleSphere.transform.position = new Vector3(obstacleSphere.transform.position.x, 0.525f, roads[1].transform.position.z);
            }      

        }

		if (other.tag == "RoadR")
		{
			frontRoadR = other.gameObject;
			other.transform.position = new Vector3(0, 0, other.transform.position.z + 40);
		
		}

		if (other.tag == "RoadL")
		{
			frontRoadL = other.gameObject;
			other.transform.position = new Vector3(0, 0, other.transform.position.z + 40);

		}
	}
}
