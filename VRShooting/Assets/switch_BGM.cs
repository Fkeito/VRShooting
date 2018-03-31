using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switch_BGM : MonoBehaviour {

    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    private AudioSource audioSource;
    private int flag = 1;
    Slider playerslider;
	
	void Start () {
        playerslider = GameObject.Find("HP").GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();
	}
	

	void Update () {
        if(playerslider.value <= 30 && flag ==1){
            audioSource.Stop();
            audioSource.clip = audioClip2;
            audioSource.Play();
            flag = flag - 1;
        }
		
        if (playerslider.value == 0 && flag == 0)
        {
            audioSource.Stop();
            audioSource.clip = audioClip3;
            audioSource.Play();
            flag = flag - 1;
        }
	}
}
