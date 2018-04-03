using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guard : MonoBehaviour {
    public AudioClip sound;

    public void Attacked()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
