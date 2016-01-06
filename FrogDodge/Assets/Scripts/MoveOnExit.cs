using UnityEngine;
using System.Collections;

public class MoveOnExit : MonoBehaviour
{
	Rigidbody rg;
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Boundary") {

			rg = GetComponent<Rigidbody>();
			Vector3 position = rg.position;
			rg.position.Set(position.x, position.y , position.z + 40);

		}
	}

}
