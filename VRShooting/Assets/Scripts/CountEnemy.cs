using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemy : MonoBehaviour {

    GameObject[] Enemies;
    public int EnemyNum;
    private Text EnemyText;

	void Start () {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyNum = Enemies.Length;
        EnemyText = GetComponentInChildren<Text>();
	}

	void Update () {
        EnemyText.text = "Enemy:" + EnemyNum.ToString("00");
	}
}
