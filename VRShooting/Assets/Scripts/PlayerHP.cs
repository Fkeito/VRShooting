using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

    Slider playerslider;
    float damage = 10;

	private void Start()
	{
        playerslider = GameObject.Find("HP").GetComponent<Slider>();
	}
	private void OnCollisionEnter(Collision collision)
    {
        playerslider.value -= damage;
    }

}

