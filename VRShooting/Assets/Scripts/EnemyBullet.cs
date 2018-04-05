using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Enemy")) Destroy(this.gameObject);
    }
}
