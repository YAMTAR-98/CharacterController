using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBrain_Stupid : MonoBehaviour
{
    public GameObject target;
    float attackDistance;
    Animator anim;
    private NavMeshAgent navMeshAgent;
    public GameObject hitPoint;
    private void Awake() {
        
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        attackDistance = navMeshAgent.stoppingDistance;
    }


    void Update()
    {
        if(target != null){
            bool inRange = Vector3.Distance(transform.position, target.transform.position) <= attackDistance;

            if(inRange)
                LookAtTarget();
            else
                UpdatePath();

            if(anim.GetBool("Die")){
                anim.SetBool("Attack", false);
            }else
                anim.SetBool("Attack", inRange);
        }
        
    }
    void UpdatePath(){
        navMeshAgent.SetDestination(target.transform.position);
    }
    void LookAtTarget(){
        Vector3 lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 2.0f);
    } 
    internal void Die(){
        anim.SetBool("Die", true);
        target = null;
    }
    public void HitPlayer(){
        hitPoint.SetActive(true);
    }
    public void CloseTrigger(){
        hitPoint.SetActive(false);
    }
}
