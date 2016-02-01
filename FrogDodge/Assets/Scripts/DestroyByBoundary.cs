 using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class DestroyByBoundary : MonoBehaviour {

	Rigidbody rg;
    public GameObject player;
    public GameObject backRoad, frontRoad;
	public List<GameObject> set1;
	private List<List<GameObject>> disabledRoadList;
	public List<GameObject> disabledRoads;
	public List<GameObject> currentList;
	private List<List <GameObject>> roadLists;
	private IEnumerator<GameObject> enumerator;

    void Start()
    {
        disabledRoads = new List<GameObject>();
		roadLists = new List<List<GameObject>>();
		disabledRoadList = new List<List<GameObject>>();
		roadLists.Add(set1);
		currentList = roadLists[0];
		enumerator = currentList.GetEnumerator();
    }

    

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        //print(frontRoad.name);
 
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Road")
        {
            frontRoad = other.gameObject;
        }
    }


    void OnTriggerExit(Collider other)
	{
		if (other.tag == "Road") {
			Vector3 frontPosition = new Vector3 (other.transform.position.x, other.transform.position.y, frontRoad.transform.position.z + frontRoad.GetComponent<BoxCollider> ().size.z);

			other.gameObject.SetActive (false);

			if (roadLists.Count > 0) 
			{
				
				disabledRoads.Add (other.gameObject);

				if (enumerator.MoveNext ()) {
					
					Instantiate (enumerator.Current, frontPosition, Quaternion.identity);

				} else {
					roadLists.Remove(currentList);

					disabledRoadList.Add(disabledRoads);
					disabledRoads = new List<GameObject> ();

					if (roadLists.Count > 0) {

						currentList = roadLists [Random.Range (0, roadLists.Count)];
						enumerator = currentList.GetEnumerator ();
						enumerator.MoveNext();

						Instantiate (enumerator.Current, frontPosition, Quaternion.identity);
					} else {
						
						currentList = disabledRoadList [Random.Range (0, disabledRoadList.Count)];
						enumerator = currentList.GetEnumerator ();
						enumerator.MoveNext();

					}
				}

			} else {
				if (enumerator.MoveNext ()) {
					print ("Has Next");
				} else {
					currentList = disabledRoadList [Random.Range (0, disabledRoadList.Count)];
					enumerator = currentList.GetEnumerator ();
					enumerator.MoveNext ();
				}
				PrefabUtility.ResetToPrefabState (enumerator.Current);
				enumerator.Current.SetActive (true);
				//Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
				enumerator.Current.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, frontRoad.transform.position.z + frontRoad.GetComponent<BoxCollider> ().size.z);
		
			}
		}

		/*
		if (other.tag == "Road")
        {
            backRoad = other.gameObject;

            //Disabled road count is 1 to reflect 5 roads with the current Boundary size.
            if (disabledRoads.Count <= 1)
            {
                other.gameObject.SetActive(false);
                disabledRoads.Add(other.gameObject);
            }
            else
            {
                other.gameObject.SetActive(false);
                disabledRoads.Add(other.gameObject);
                GameObject temp = disabledRoads[Random.Range(0, disabledRoads.Count)];
                disabledRoads.Remove(temp);
                PrefabUtility.ResetToPrefabState(temp);
                temp.SetActive(true);
                //Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
                temp.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, frontRoad.transform.position.z + frontRoad.GetComponent<BoxCollider>().size.z);
            }
      */
            // other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z + 40);
           // if (other.name == "Road 1")
           // {
               
                //Move the obstacles on that road when the road moves
                //Instantiate(obstacle, new Vector3(frontRoad.transform.position.x - 8f, 0.525f, frontRoad.transform.position.z), Quaternion.identity);
              // obstacleCube.transform.position = new Vector3(obstacleCube.transform.position.x, obstacleCube.transform.position.y, roads[0].transform.position.z);
            //}
            // if(other.name == "Road 2")
            //{
               // obstacleSphere.transform.position = new Vector3(obstacleSphere.transform.position.x, obstacleSphere.transform.position.y, roads[1].transform.position.z);
            //}      

        //}

	}
}
