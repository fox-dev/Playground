 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByBoundary : MonoBehaviour {

	Rigidbody rg;
    public GameObject player;
    public GameObject backRoad, frontRoad;
    public List<GameObject> set1, set2;
	private List<List<GameObject>> disabledRoadList;
	public List<GameObject> disabledRoads;
	public List<GameObject> currentList;
	private List<List <GameObject>> roadLists;
	private IEnumerator<GameObject> enumerator;

    public List<GameObject> initialSet; //for objects already in scene.
    public List<int> setLength; // to keep track of the length for each set put in.
    public int numSets;

    public bool makingRoads, initialSet_in;

    void Start()
    {
        disabledRoads = new List<GameObject>();
		roadLists = new List<List<GameObject>>();
		disabledRoadList = new List<List<GameObject>>();

		roadLists.Add(set1);
        setLength.Add(set1.Count);

        roadLists.Add(set2);
        setLength.Add(set2.Count);

        currentList = roadLists[0];
		enumerator = currentList.GetEnumerator();

        numSets = roadLists.Count + 1; // +1 to account for existing set in the scene.

        makingRoads = true;
        initialSet_in = false;

    }

    

    void Update()
    {
       // print("Count is:" + roadLists.Count);

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

        if(other.tag == "Road")
        {
			Vector3 frontPosition = new Vector3(other.transform.position.x, transform.position.y, frontRoad.transform.position.z + 44);
            
            other.gameObject.SetActive(false);

            if(makingRoads == true) //instantiating roads block
            {
                if (roadLists.Count > 0) //this block for instantiating roads
                {
                    if (enumerator.MoveNext())
                    {
                        if(currentList[currentList.Count-1].Equals(enumerator.Current)) //Last object in list to be instantiated
                        {
                            print("Putting in last object");
                            roadLists.Remove(currentList);
                            if(roadLists.Count == 0)
                            {
                                makingRoads = false;
                            }
                        }
                        Instantiate(enumerator.Current, frontPosition, Quaternion.identity);
                        
                    }
                    else
                    {
                        roadLists.Remove(currentList); 
                        if (roadLists.Count > 0) //if 0, no longer assign roadLists to currentList and stop instantiating
                        {
                            currentList = roadLists[Random.Range(0, roadLists.Count)];
                            enumerator = currentList.GetEnumerator();
                            if (enumerator.MoveNext())
                            {
                                Instantiate(enumerator.Current, frontPosition, Quaternion.identity);
                               
                            }
                        }    
                    }
                }
                //Want to handle making sets now
                if (initialSet.Count < 6 && initialSet_in == false) //number of road objects in scene is #
                {
                    initialSet.Add(other.gameObject);
                    if (initialSet.Count == 6) //if the last initial road is put in.
                    {
                        print("Last initial set is in");
                        disabledRoadList.Add(initialSet);
                        initialSet_in = true;
                    }

                }
                else //start adding in the instantiated sets
                {
                   if(setLength.Count > 0 && setLength[0] > 0)
                   {
                        disabledRoads.Add(other.gameObject);
                        setLength[0] = setLength[0] - 1;
                        print(setLength[0] + " remaining " + setLength.Count + " sets left");
                        if(setLength[0] == 0)
                        {
                            setLength.RemoveAt(0);
                            disabledRoadList.Add(disabledRoads);
                            disabledRoads = new List<GameObject>();
                            print(setLength[0] + " remaining ");

                        }
                   }
                }
            } //Making Roads bracket.
            else if (setLength.Count > 0 && setLength[0] > 0 && makingRoads == false) //Continue adding the instantiated roads to their sets
            {
                disabledRoads.Add(other.gameObject);
                setLength[0] = setLength[0] - 1;
                print(setLength[0] + " remaining " + setLength.Count + " sets left");
                if (setLength[0] == 0)
                {
                    setLength.RemoveAt(0);
                    disabledRoadList.Add(disabledRoads);
                    disabledRoads = new List<GameObject>();
                } 

                if (enumerator.MoveNext()) //begin using the inputted sets while remaining sets are put into disabledRoadList;
                {
                    if (currentList[currentList.Count - 1].Equals(enumerator.Current)) //last object in set
                    {
                        print("placing last set piece");
                    }
                    //PrefabUtility.ResetToPrefabState(enumerator.Current);
                    enumerator.Current.SetActive(true);
					enumerator.Current.transform.position = frontPosition;
                }
                else {
                    print("Starting new roads");
                    bool found = false;
                    while (found == false) //look for a set that is not currently in use.
                    {
                        currentList = disabledRoadList[Random.Range(0, disabledRoadList.Count)];
                        for (int x = 0; x < currentList.Count; x++)
                        {
                            if (currentList[x].gameObject.activeSelf == true)
                            {
                                found = false;
                                break;
                            }
                            else
                            {
                                found = true;
                            }

                        }
                    }
                    enumerator = currentList.GetEnumerator();
                    enumerator.MoveNext();
                    //PrefabUtility.ResetToPrefabState(enumerator.Current);
                    enumerator.Current.SetActive(true);
					enumerator.Current.transform.position = frontPosition;
                }
            }
            else //Main road loop starts now;
            {
                if (enumerator.MoveNext())
                {
                    if (currentList[currentList.Count - 1].Equals(enumerator.Current)) //last object in set
                    {
                        print("placing last set piece 2");
                    }
                   // PrefabUtility.ResetToPrefabState(enumerator.Current);
                    enumerator.Current.SetActive(true);
                    //Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
					enumerator.Current.transform.position = frontPosition;
                }
                else {
                    bool found = false;
                    while(found == false) //look for a set that is not currently in use.
                    {
                        currentList = disabledRoadList[Random.Range(0, disabledRoadList.Count)];
                        for(int x = 0; x < currentList.Count; x++)
                        {
                            if(currentList[x].gameObject.activeSelf == true)
                            {
                                found = false;
                                break;
                            }
                            else
                            {
                                found = true;
                            }
                            
                        }
                    }
                    enumerator = currentList.GetEnumerator();
                    enumerator.MoveNext();
                    //PrefabUtility.ResetToPrefabState(enumerator.Current);
                    enumerator.Current.SetActive(true);
                    //Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
					enumerator.Current.transform.position = frontPosition;
                }
            }
        }
    }


    /*
    void OnTriggerExit(Collider other)
    {
        print(disabledRoadList.Count);
        if (other.tag == "Road") {
            Vector3 frontPosition = new Vector3(other.transform.position.x, other.transform.position.y, frontRoad.transform.position.z + frontRoad.GetComponent<BoxCollider>().size.z);

           
            other.gameObject.SetActive(false);

            if (roadLists.Count > 0 || disabledRoadList.Count < numSets) 
			{
				
				disabledRoads.Add (other.gameObject);

				if (enumerator.MoveNext ()) {
					
					Instantiate (enumerator.Current, frontPosition, Quaternion.identity);

				} else {
					roadLists.Remove(currentList);

					disabledRoadList.Add(disabledRoads);
					disabledRoads = new List<GameObject> ();

                    if (roadLists.Count > 0) {
                        print("Using normal roadList");
                        currentList = roadLists[Random.Range(0, roadLists.Count)];
                        enumerator = currentList.GetEnumerator();
                        enumerator.MoveNext();

                        Instantiate(enumerator.Current, frontPosition, Quaternion.identity);
                    } else if(disabledRoadList.Count < numSets)
                    {
                        print("Using disabledRoadList");
                        currentList = disabledRoadList[Random.Range(0, disabledRoadList.Count)];
                        enumerator = currentList.GetEnumerator();
                        enumerator.MoveNext();
                        //PrefabUtility.ResetToPrefabState(enumerator.Current); 
                        GameObject temp = enumerator.Current;
                        temp.SetActive(true);
                        print(enumerator.Current.activeSelf);

                        //Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
                        temp.transform.position = frontPosition;
                    }
                    else {
                        print("About to exit");
                        currentList = disabledRoadList [Random.Range (0, disabledRoadList.Count)];
						enumerator = currentList.GetEnumerator ();
						enumerator.MoveNext();

					}
				}

			} else {
				if (enumerator.MoveNext ()) {
					print ("Has Next");
				} else {
					currentList = disabledRoadList [Random.Range(0, disabledRoadList.Count)];
					enumerator = currentList.GetEnumerator ();
					enumerator.MoveNext ();
				}
				PrefabUtility.ResetToPrefabState (enumerator.Current);
				enumerator.Current.SetActive (true);
				//Get front road's position and attach the next road right after it; frontroad size is handled accordingly.
				enumerator.Current.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, frontRoad.transform.position.z + frontRoad.GetComponent<BoxCollider> ().size.z);
		
			}
		}


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

	}*/

}
