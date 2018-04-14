using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIT : MonoBehaviour {

    public AudioClip sound;
    

    void OnTriggerEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
