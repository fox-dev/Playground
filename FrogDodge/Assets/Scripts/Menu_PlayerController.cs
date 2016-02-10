using UnityEngine;
using System.Collections;

public class Menu_PlayerController : MonoBehaviour
{

    bool inside, left, right;
    ArrayList obstacles;


    Rigidbody rg;
    Vector3 startPos, endPos;
    Quaternion startRot, endRot;

    private GameObject endRotation;

    private float lerp = 0, duration = 5f;
    public float speed, rotSpeed, moveDistance;
    public int rotationInDegrees;

    Animator anim;

    int moveHash = Animator.StringToHash("Roll");
    int stopHash = Animator.StringToHash("Stop");

    void Start()
    {
        inside = false;
        obstacles = new ArrayList();
        startPos = transform.position;
        endPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        startRot = transform.rotation;
        endRotation = new GameObject();
        endRotation.transform.rotation = transform.rotation;

        anim = GetComponent<Animator>();

        rg = GetComponent<Rigidbody>();

        //GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<MeshRenderer>().enabled = false;
        MeshRenderer[] childRenders = GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer r in childRenders)
        {
            r.enabled = false;
        }

  

    }

    void Update()
    {


        lerp += Time.deltaTime / duration;


        //float move = Input.GetAxis("Vertical");
        //anim.SetFloat("Speed", move);

        //transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

        //transform.rotation = Quaternion.Lerp(transform.rotation, endRotation.transform.rotation, rotSpeed * Time.deltaTime);

        //Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);

        Vector3 movement = new Vector3(0.0f, 0.0f, 1f);

        rg.velocity = movement * speed;
    }



 
}
