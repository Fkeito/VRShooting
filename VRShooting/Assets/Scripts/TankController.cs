using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : EnemyBase {

    public TankMode tankMode;

    public GameObject turret;
    private GameObject player;
    public GameObject bullet;
    public GameObject explosion;

    public int m_PlayerNumber = 1;              // Used to identify which tank belongs to which player.  This is set by this tank's manager.
    public float m_Speed = 50f;                 // How fast the tank moves forward and back.
    public float m_TurnSpeed = 3f;            // How fast the tank turns in degrees per second.
    public AudioSource m_MovementAudio;         // Reference to the audio source used to play engine sounds. NB: different to the shooting audio source.
    public AudioClip m_EngineIdling;            // Audio to play when the tank isn't moving.
    public AudioClip m_EngineDriving;           // Audio to play when the tank is moving.
    public float m_PitchRange = 0.2f;           // The amount by which the pitch of the engine noises can vary.
    
    private float m_OriginalPitch;              // The pitch of the audio source at the start of the scene.
    private ParticleSystem[] m_particleSystems; // References to all the particles systems used by the Tanks

    public Vector3 targetPosition;

    private float changeTargetSqrDistance = 1f;

    private Vector3 startPos;

    private bool attack = false;
    
    private void OnEnable()
    {
        // We grab all the Particle systems child of that Tank to be able to Stop/Play them on Deactivate/Activate
        // It is needed because we move the Tank when spawning it, and if the Particle System is playing while we do that
        // it "think" it move from (0,0,0) to the spawn point, creating a huge trail of smoke
        m_particleSystems = GetComponentsInChildren<ParticleSystem>();
        for (int i = 0; i < m_particleSystems.Length; ++i)
        {
            m_particleSystems[i].Play();
        }
    }


    private void OnDisable()
    {

        // Stop all particle system so it "reset" it's position to the actual one instead of thinking we moved when spawning
        for (int i = 0; i < m_particleSystems.Length; ++i)
        {
            m_particleSystems[i].Stop();
        }

        GameObject obj = Instantiate(explosion);
        obj.transform.position = this.gameObject.transform.position;
        Destroy(obj, 2f);
    }


    private void Start()
    {
        
        // Store the original pitch of the audio source.
        m_OriginalPitch = m_MovementAudio.pitch;

        startPos = this.gameObject.transform.position;
        targetPosition = GetRandomPositionOnLevel();

        //*
        GameObject tmpObj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        tmpObj.transform.parent = GameObject.Find("Player").transform;
        tmpObj.transform.position = new Vector3(0.4f, 2.2f, -0.6f);
        tmpObj.GetComponent<MeshRenderer>().enabled = false;
        player = tmpObj;
        //*/

        //player = GameObject.Find("Controller (right)");

        StartCoroutine("Attack");
    }


    private void Update()
    {
        EngineAudio();
    }


    private void EngineAudio()
    {
            // ... and if the audio source is currently playing the driving clip...
            if (m_MovementAudio.clip == m_EngineDriving)
            {
                // ... change the clip to idling and play it.
                m_MovementAudio.clip = m_EngineIdling;
                m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
                m_MovementAudio.Play();
            }
    }


    private void FixedUpdate()
    {
        attack = true;

        //*


        // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
        float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
            if (sqrDistanceToTarget < changeTargetSqrDistance)
            {
                targetPosition = GetRandomPositionOnLevel();
            }

            // 目標地点の方向を向く
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * m_TurnSpeed);

            // 前方に進む
            //m_Rigidbody.velocity = (this.transform.forward * m_Speed * Time.deltaTime);
            transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
            //*/
            
            turret.transform.LookAt(player.transform);
        

    }

    public Vector3 GetRandomPositionOnLevel(float levelSize = 10f)
    {
        Debug.Log("Set");
        return new Vector3(startPos.x + Random.Range(-levelSize, levelSize), 0, startPos.z + Random.Range(-levelSize, levelSize));
    }
    public Vector3 GetRandomPositionOnLevel(float levelSize, Vector3 normPosition)
    {
        Debug.Log("Set");
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }


    public void ResetStartPos()
    {
        startPos = this.gameObject.transform.position;
    }

    public void Fire()
    {

       //Vector3 rand = new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f));
       //turret.transform.forward += rand;


        GameObject obj = Instantiate(bullet);
        obj.transform.position = turret.transform.position + turret.transform.forward * 2f;
        obj.transform.LookAt(turret.transform);
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(obj.transform.forward * -1500);

        Destroy(obj, 50f);
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (attack) Fire();

            yield return new WaitForSeconds(Random.Range(3f,8f));
        }
    }
}
public enum TankMode
{
    wandering,
    movingTo,
    shooting,
    stop,
}
