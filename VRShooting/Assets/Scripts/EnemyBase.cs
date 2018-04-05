using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    private int point = 1;
    public int hp = 1;

    public void Attacked(){
        hp--;

        if(hp <= 0){
            PlayerController.score += point;

            Destroy(this.gameObject);
        }
    }

}
