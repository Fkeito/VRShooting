using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTank : MonoBehaviour {

    public GameObject tank;
    public TankController tCon;

    void Start()
    {
        //tCon.tankMode = TankMode.shooting;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            tCon.Fire();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(tCon.gameObject);
            tCon = null;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!tCon)
            {
                tCon = Instantiate(tank).GetComponent<TankController>();
                tCon.tankMode = TankMode.shooting;
            }
        }
    }
}
