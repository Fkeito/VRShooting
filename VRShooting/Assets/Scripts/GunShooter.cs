using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooter : MonoBehaviour {

    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;
    [SerializeField]
    private Transform Zyukou;
    [SerializeField]
    private GameObject GunBullet;
    [SerializeField]
    private float BulletSpeed;
    [SerializeField]
    private new Animation animation;
    [SerializeField]
    private float PulseMaxTime;
    private float PulseCurrentTime=0f;
    void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        if (trackedObject.gameObject.activeSelf)
        {
            device = SteamVR_Controller.Input((int)trackedObject.index);
        }
        if (animation.IsPlaying("Shoot"))
        {
            PulseCurrentTime += Time.deltaTime;
            if (PulseCurrentTime < PulseMaxTime)
            {
                device.TriggerHapticPulse(3000);
            }
            return;
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)||Input.GetKey(KeyCode.J))
        {
            //Debug.Log("Fire!");
            Fire();
        }
        
	}

    void Fire(){
        Vector3 firePos = Zyukou.transform.position;
        Vector3 dir = -Zyukou.transform.forward;
        Ray ray = new Ray(firePos, dir);
        //Debug.DrawRay(ray.origin, ray.direction * 10f);
        GameObject bullet=Instantiate(GunBullet,firePos,new Quaternion());
        RaycastHit hit;
        //EnemyBase enemy = null;
        GameObject obj=null;
        if (Physics.Raycast(ray, out hit))
        {
            obj = hit.collider.gameObject;
            bullet.GetComponent<GunBullet>().Shot(dir,BulletSpeed,obj.transform.position);
        }
        else
        {
            bullet.GetComponent<GunBullet>().Shot(dir, BulletSpeed);
        }
        animation.Play("Shoot");
        PulseCurrentTime = 0;
        if(obj.GetComponent<EnemyBase>()){
            obj.GetComponent<EnemyBase>().Attacked();
        }
    }


}
