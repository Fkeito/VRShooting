using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFighter : MonoBehaviour {

    public GameObject fighter;
    public FighterController fCon;

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fCon.Attack();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(fCon.gameObject);
            fCon = null;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!fCon)
            {
                fCon = Instantiate(fighter).GetComponent<FighterController>();
            }
        }
    }
}
