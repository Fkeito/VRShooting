using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J))
        {
            device = SteamVR_Controller.Input((int)trackedObject.index);
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("Fire!");
            Fire();
        }
	}

    void Fire(){
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10f);

        RaycastHit hit;
        EnemyBase enemy = null;

        if (Physics.Raycast(ray, out hit))
        {
            enemy = hit.collider.gameObject.GetComponent<EnemyBase>();
        }

        if(enemy){
            enemy.Attacked();
        }
    }


}
