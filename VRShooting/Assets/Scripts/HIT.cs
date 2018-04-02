using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIT : MonoBehaviour {

    public AudioClip sound;

    void Start()
    {
       
        Debug.Log("kaku");
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
