using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] float ChaseSpeed = 10.5f;
    [SerializeField] GameObject Patrol;
    [SerializeField] float AttackDistance = 3f;
    [SerializeField] GameObject ChaseMusic;
    [SerializeField] float MaxDistance = 20.0f;

    [SerializeField] bool HaveAxe = false;
    [SerializeField] bool HaveBat = false;
    [SerializeField] bool HaveKnife = false;
    [SerializeField] bool HaveGun = false;

    public float DistanceToPlayer;
    private bool RunToPlayer = false;
    private Animator anim;
    private NavMeshAgent nav;
    private bool MusicOn = false;
    private float NewChaseSpeed = 0.0f;


    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        Patrol.gameObject.SetActive(true);
        ChaseMusic.gameObject.SetActive(false);
        MusicOn = false;
        NewChaseSpeed = ChaseSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerPlayer"))
        {
            RunToPlayer = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (RunToPlayer == true)
        {
            DistanceToPlayer = Vector3.Distance(Player.position, transform.position);

            if (DistanceToPlayer < MaxDistance)
            {
                if (MusicOn == false)
                {
                    ChaseMusic.gameObject.SetActive(true);
                    MusicOn = true;
                }
            }
            else if (DistanceToPlayer > MaxDistance)
            {
                if (MusicOn == true)
                {
                    ChaseMusic.gameObject.SetActive(false);
                    MusicOn = false;
                }
            }

            Patrol.gameObject.SetActive(false);
            nav.speed = NewChaseSpeed;
            nav.SetDestination(Player.position);

            if (DistanceToPlayer < AttackDistance)
            {

                if (HaveBat == true)
                {
                    anim.SetBool("BatAttacks", true);
                    NewChaseSpeed = 6.5f;
                    nav.angularSpeed = 650000000;
                }
                if (HaveAxe == true)
                {
                    anim.SetBool("AxeAttacks", true);
                    NewChaseSpeed = 6.5f;
                    nav.angularSpeed = 650000000;
                }
                if (HaveKnife == true)
                {
                    anim.SetBool("KnifeAttacks", true);
                    NewChaseSpeed = 6.5f;
                    nav.angularSpeed = 650000000;
                }
                if (HaveGun == true)
                {
                    anim.SetBool("GunAttacks", true);
                    NewChaseSpeed = 6.5f;
                    nav.angularSpeed = 650000000;
                }
            }

            else if (DistanceToPlayer > AttackDistance)
            {
                if (HaveBat == true)
                {
                    anim.SetBool("Alert", true);
                    anim.SetBool("BatAttacks", false);
                    NewChaseSpeed = ChaseSpeed;
                    nav.angularSpeed = 25000;
                }
                if (HaveAxe == true)
                {
                    anim.SetBool("Alert", true);
                    anim.SetBool("AxeAttacks", false);
                    NewChaseSpeed = ChaseSpeed;
                    nav.angularSpeed = 25000;
                }
                if (HaveKnife == true)
                {
                    anim.SetBool("Alert", true);
                    anim.SetBool("KnifeAttacks", false);
                    NewChaseSpeed = ChaseSpeed;
                    nav.angularSpeed = 25000;
                }
                if (HaveGun == true)
                {
                    anim.SetBool("Alert", true);
                    anim.SetBool("GunAttacks", false);
                    NewChaseSpeed = ChaseSpeed;
                    nav.angularSpeed = 25000;
                }
            }
        }
    }
}
