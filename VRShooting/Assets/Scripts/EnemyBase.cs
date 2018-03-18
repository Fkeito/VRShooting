using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    protected int point;

    protected int _hp;
    public int hp{ get{ return _hp; } }

    public void Attacked(){
        _hp--;

        if(hp <= 0){
            PlayerController.score += point;

            Destroy(this.gameObject);
        }
    }

}
