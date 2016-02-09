using UnityEngine;
using System.Collections;

public class TrainAudioScript : MonoBehaviour {

    public AudioClip trainL, trainR;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TrainToLeft")
        {
           
            GetComponent<AudioSource>().Play();

        }
        else if (other.tag == "TrainToRight")
        {
            
            GetComponent<AudioSource>().Play();
        }
    }
}
