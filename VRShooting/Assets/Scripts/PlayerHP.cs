using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    Slider playerslider;
    float damage = 10;

    public GameObject gameover;

	private void Start()
	{
        playerslider = GameObject.Find("HP").GetComponent<Slider>();
	}
	private void OnTriggerEnter(Collider collision)
    {
        playerslider.value -= damage;
        if(playerslider.value <= 0)
        {
            gameover.SetActive(true);
        }
    }

}

