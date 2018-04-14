using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : EnemyBase
{
    private GameObject player;
    public GameObject cannon;

    public GameObject bullet;
    public GameObject explosion;
    public static float second;
    public static float bulletSpeed;

    // Use this for initialization
    void Start()
    {
        //*
        GameObject tmpObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        tmpObj.transform.parent = GameObject.Find("Player").transform;
        tmpObj.transform.position = new Vector3(-1.9f, 2.5f, 2.1f);
        tmpObj.GetComponent<MeshRenderer>().enabled = false;
        player = tmpObj;
        //*/

        //player = GameObject.Find("Controller (right)");

        StartCoroutine("attcksuru");
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

        //Vector3 rand = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
        //cannon.transform.forward += rand;

        Invoke("Fire", 0.3f);
    }

    void Fire()
    {
        GameObject obj = Instantiate(bullet);
        obj.transform.position = cannon.transform.forward + cannon.transform.position; ;
        obj.transform.LookAt(cannon.transform);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(obj.transform.forward * (-bulletSpeed));

        Destroy(obj, 15f);
    }
    private IEnumerator attcksuru() {
        while (true) {
            float _second = Random.Range(second, second + 1.5f);
            yield return new  WaitForSeconds(_second);
            Debug.Log("utte");
            Attack();
        }
    }
}
