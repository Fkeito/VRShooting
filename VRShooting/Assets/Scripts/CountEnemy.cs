using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemy : MonoBehaviour {
    
    public int EnemyNum;
    private Text EnemyText;

    public GameObject gameover;
    public GameObject gameclear;

	void Start () {
        EnemyNum = GameObject.FindGameObjectsWithTag("Fighter").Length+ GameObject.FindGameObjectsWithTag("Tank").Length;
        EnemyText = GetComponentInChildren<Text>();
	}

	void Update () {
        EnemyNum = GameObject.FindGameObjectsWithTag("Fighter").Length + GameObject.FindGameObjectsWithTag("Tank").Length;
        EnemyText.text = "Enemy:" + EnemyNum.ToString("00");

        if(EnemyNum <= 0)
        {
            gameclear.SetActive(true);
            Destroy(gameover);
        }
	}
}
