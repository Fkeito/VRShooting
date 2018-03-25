using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

    [SerializeField]
    private int minute;
    [SerializeField]
    private float second;
    private float totaltime;
    private float oldsecond;
    private Text timertext;

	void Start () {
        totaltime = minute * 60 + second;
        oldsecond = 0f;
        timertext = GetComponentInChildren<Text>();
	}
	
	void Update () {
        if (totaltime <= 0f) return;

        totaltime = minute * 60 + second;
        totaltime -= Time.deltaTime;

        minute = (int)totaltime / 60;
        second = totaltime - minute * 60;

        if ((int)second != (int)oldsecond) timertext.text = minute.ToString("00") + ":" + second.ToString("00");
        oldsecond = second;

        if (totaltime <= 0f) { timertext.text = "00:00"; Debug.Log("終了"); }
	}
}
