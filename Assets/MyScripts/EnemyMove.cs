using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform Target1;
    [SerializeField] Transform Target2;
    [SerializeField] Transform Target3;
    [SerializeField] Transform Target4;
    [SerializeField] Transform Target5;
    [SerializeField] Transform Target6;
    [SerializeField] Transform Target7;

    [SerializeField] int WaitTime = 0;

    

    [SerializeField] int EnemyNumber;
    [SerializeField] string TargetName;
    [SerializeField] string TargetDescriptor;

    private int CurrentTarget = 1;
    private Transform TargetPosition;
    private bool Contact = false;
    private Animator animate;
    private int LastTarget = 1;
    void Start()
    {
        TargetPosition = Target1;
        MoveToTarget();
        animate = GetComponentInParent<Animator>();
        LastTarget = CurrentTarget;
        TargetDescriptor = EnemyNumber + "TargetCube1";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyTarget"))
        {
            TargetName = other.GetComponent<Collider>().name;
            if (TargetName == TargetDescriptor)
            {

                if (Contact == false)
                {
                    Contact = true;

                    CurrentTarget = Random.Range(1, 8);
                    if (CurrentTarget == LastTarget)
                    {
                        TryAgain();
                    }
                    else
                    {
                        StartCoroutine(Waiting());
                    }

                    //MoveToTarget();
                }
            }
        }
    }
    void TryAgain()
    {
        if(LastTarget == 1)
        {
            CurrentTarget = LastTarget + 1;
        }
        else if (LastTarget >1)
        {
            CurrentTarget = LastTarget - 1;
        }
        StartCoroutine(Waiting());
    }
    void MoveToTarget()
    {
        if (Contact == false)
        {
            if (CurrentTarget == 1)
            {
                TargetPosition = Target1;
                TargetDescriptor = EnemyNumber + "TargetCube1";
            }
            if (CurrentTarget == 2)
            {
                TargetPosition = Target2;
                TargetDescriptor = EnemyNumber + "TargetCube2";
            }
            if (CurrentTarget == 3)
            {
                TargetPosition = Target3;
                TargetDescriptor = EnemyNumber + "TargetCube3";
            }
            if (CurrentTarget == 4)
            {
                TargetPosition = Target4;
                TargetDescriptor = EnemyNumber + "TargetCube4";
            }
            if (CurrentTarget == 5)
            {
                TargetPosition = Target5;
                TargetDescriptor = EnemyNumber + "TargetCube5";
            }
            if (CurrentTarget == 6)
            {
                TargetPosition = Target6;
                TargetDescriptor = EnemyNumber + "TargetCube6";
            }
            if (CurrentTarget == 7)
            {
                TargetPosition = Target7;
                TargetDescriptor = EnemyNumber + "TargetCube7";
            }
            GetComponentInParent<NavMeshAgent>().destination = TargetPosition.position;

            LastTarget = CurrentTarget;
            //Contact = false;
        }
    }
    IEnumerator Waiting()
    {
        animate.SetInteger("State", 1);
        yield return new WaitForSeconds(WaitTime);
        animate.SetInteger("State", 0);
        Contact = false;
        MoveToTarget();
    }
}
