using UnityEngine;
using System.Collections;

public class HitboxScript : MonoBehaviour {


	public GameObject myFrog;
	private PlayerController pc;

    // Use this for initialization
    void Start () {

		pc = myFrog.GetComponent <PlayerController>();
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(90, 0, 0);
        
    }

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Cube" || other.tag == "Sphere")
		{

           // pc.objectExit();
          
		}
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Cube" || other.tag == "Sphere")
		{

			if (other.transform.position.x > transform.position.x && other.GetComponent<Rigidbody>().velocity.x >= 0f)
			{
				//do nothing if object is moving to the right away from player
			}
			else if(other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
			{
				//do nothing if object is moving to the left away from player
			}
			else if (other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
			{
				//do nothing if object is moving to the left away from player
			}
			else if (other.transform.position.x < transform.position.x && other.GetComponent<Rigidbody>().velocity.x >= 0f)
			{
				//object is moving towards player from the left
				//pc.insideLeft();

			}
			else if (other.transform.position.x > transform.position.x && other.GetComponent<Rigidbody>().velocity.x <= 0f)
			{
				//object is moving towards player from the right
				//pc.insideRight();


			}




		}
	}


}
