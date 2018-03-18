using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Fire();
        }
	}

    void Fire(){
        Ray ray = new Ray(transform.position, transform.forward);

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
