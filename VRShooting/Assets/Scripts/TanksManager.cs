using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanksManager : MonoBehaviour {

    private GameObject[] tanks;
    private int tankNum = 6;

    private Vector3 normPosForMove;

	// Use this for initialization
	void Start () {
        tanks = GameObject.FindGameObjectsWithTag("Tank");
        normPosForMove = new Vector3(250, 0, 250);

        foreach(GameObject tank in tanks)
        {
            tank.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (GameObject tank in tanks)
            {
                tank.SetActive(true);
            }
        }
	}

    void MoveTank()
    {
        GameObject tank = tanks[tankNum];
        for(int i = tankNum;i < tanks.Length; i++)
        {
            if (tank) break;
            tank = tanks[tankNum];
        }

        float levelSize = 60;
        tank.GetComponent<TankController>().targetPosition = new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
}
