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
    private int lminute;
    private Text timertext;

    Slider playerslider;

    public GameObject gameover;
    private bool counting = false;

	void Start () {
        totaltime = minute * 60 + second;
        oldsecond = 0f;
        timertext = GetComponentInChildren<Text>();
        playerslider = GameObject.Find("HP").GetComponent<Slider>();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.S)){
            counting = true;
        }
        if (counting)
        {
            if (totaltime <= 0f)
            {
                gameover.SetActive(true);
                return;
            }

            totaltime = minute * 60 + second;
            totaltime -= Time.deltaTime;

            minute = (int)totaltime / 60;
            second = totaltime % 60;

            lminute = minute + 1;

            if ((int)second != (int)oldsecond)
            {
                if (second.ToString("00") == "60") timertext.text = lminute.ToString("00") + ":00";
                else timertext.text = minute.ToString("00") + ":" + second.ToString("00");
            }
            oldsecond = second;

            if (playerslider.value <= 0) totaltime = 0f;

            if (totaltime <= 0f) { timertext.text = "00:00"; Debug.Log("終了"); }
        }
	}
}
