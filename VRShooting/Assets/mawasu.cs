using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mawasu : MonoBehaviour {
    public float Second;
	void Update () {
        transform.eulerAngles += new Vector3(0,-Time.deltaTime*360/Second,0);
	}
}
