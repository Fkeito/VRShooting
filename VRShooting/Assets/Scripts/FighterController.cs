using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : EnemyBase
{

    private Vector3 bulletPos;

    public GameObject bullet;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        bulletPos = new Vector3(0, -0.2f, -1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(this.gameObject);
        }
    }

    void OnDisable()
    {
        Dead();
    }

    void Fire()
    {
        GameObject obj = Instantiate(bullet);
        obj.transform.position = bulletPos;
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(obj.transform.forward * -100);

        Destroy(obj, 5f);
    }

    void Dead()
    {
        GameObject obj = Instantiate(explosion);
        Destroy(obj, 2f);
    }

}
