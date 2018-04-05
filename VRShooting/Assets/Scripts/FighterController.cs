using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : EnemyBase
{
    private GameObject player;
    public GameObject cannon;

    public GameObject bullet;
    public GameObject explosion;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        GameObject obj = Instantiate(explosion);
        obj.transform.position = this.gameObject.transform.position;
        Destroy(obj, 2f);
    }

    public void Attack()
    {
        cannon.transform.LookAt(player.transform);

        Vector3 rand = new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        cannon.transform.forward += rand;

        Invoke("Fire", 0.3f);
    }

    void Fire()
    {
        GameObject obj = Instantiate(bullet);
        obj.transform.position = cannon.transform.forward;
        obj.transform.LookAt(cannon.transform);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(obj.transform.forward * -300);

        Destroy(obj, 2f);
    }
}
