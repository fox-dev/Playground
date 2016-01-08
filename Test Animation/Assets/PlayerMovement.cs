using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    int moveHash = Animator.StringToHash("Roll");
    int stopHash = Animator.StringToHash("Stop");

    Animator anim;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown("space"))         
        {

            // anim.Play("Roll");
            anim.SetTrigger(moveHash);
        }
        else
        {
            anim.SetTrigger(stopHash);
        }
	
	}
}
