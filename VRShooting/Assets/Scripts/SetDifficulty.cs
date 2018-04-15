using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SetDifficulty : MonoBehaviour {

    private GameObject canvas;
    private CountDownTimer timer;
    private CountEnemy counter;

    public GameObject enemys;
    public TankMode tankMode;
    public float tankBulletSpeed;
    public float fighterBulletSpeed;
    public float fighterBulletInterval;

    void Awake()
    {
        canvas = GameObject.Find("DifficultyCanvas");
        timer = GameObject.Find("GUI/Timer").GetComponent<CountDownTimer>();
        counter = GameObject.Find("GUI/EnemyCounter").GetComponent<CountEnemy>();
    }
    
    public void OnSelected()
    {
        TankController.tankMode = tankMode;
        TankController.bulletSpeed = tankBulletSpeed;
        FighterController.bulletSpeed = fighterBulletSpeed;
        FighterController.second = fighterBulletInterval;

        StartCoroutine(DelayMethod(0.3f, () =>
        {
            enemys.SetActive(true);
            timer.counting = true;
            counter.enabled = true;

            Destroy(canvas);
        }));
    }

    private IEnumerator DelayMethod(float delaytime,Action action)
    {
        yield return new WaitForSeconds(delaytime);
        action();
    }
}
