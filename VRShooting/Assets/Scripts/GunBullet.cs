using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour {
    private Vector3 Dir { get; set; }
    private float Speed { get; set; }
    private bool hasGoal;
    public void Shot(Vector3 dir,float speed) {
        Dir = dir.normalized;
        Speed = speed;
        gameObject.SetActive(true);
    }
    public void Shot(Vector3 dir, float speed,Vector3 Goal)
    {
        float time = (transform.position - Goal).sqrMagnitude / speed;
        hasGoal = true;
        Shot(dir, speed);
        Destroy(gameObject,time);
    }
    private void Update()
    {
        if (!gameObject.activeSelf) return;
        transform.position += Dir * Speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasGoal) {
            gameObject.SetActive(false);
            return;
        }
        Destroy(gameObject);
    }
}
