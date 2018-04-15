using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject enemys1;
    public GameObject enemys2;
    public GameObject enemys3;
    public GameObject safety;

    void OnEnable()
    {
        safety.SetActive(true);
        enemys1.SetActive(false);
        enemys2.SetActive(false);
        enemys3.SetActive(false);
    }
}
