using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_Color : MonoBehaviour
{



    private int flag = 1;
    Slider playerslider1;
    public Image playerslider2;


    void Start()
    {
        playerslider1 = GameObject.Find("HP").GetComponent<Slider>();
        playerslider2 = GameObject.Find("Fill").GetComponent<Image>();

    }
    void Update()
    {
        if (playerslider1.value <= 50 && flag == 1)
        {

            playerslider2.color = Color.yellow;
            flag = flag - 1;
        }

        if (playerslider1.value <= 30 && flag == 0)
        {
            playerslider2.color = Color.red;
            flag = flag - 1;
        }

    }
}