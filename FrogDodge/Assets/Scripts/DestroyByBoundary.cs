using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	Rigidbody rg;

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Road")
		{
			other.transform.position = new Vector3 (0, 0, transform.position.z + 40f);
		}
		else
		{
			Destroy (other.gameObject);
		}
	}
}
