using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIT : MonoBehaviour {

    public AudioClip sound;
    

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}