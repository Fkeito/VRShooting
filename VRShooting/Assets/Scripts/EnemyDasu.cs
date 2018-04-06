using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDasu : MonoBehaviour {

    public GameObject enemys;
    public GameObject aaa;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            enemys.SetActive(true);
            Destroy(aaa);
            Destroy(this);
        }
	}
}
