using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetHealth : MonoBehaviour
{
    [SerializeField] internal float health = 100f;
    EnemyBrain_Stupid enemyBrain;

    private void Start() {
        enemyBrain = GetComponent<EnemyBrain_Stupid>();
    }
    public void IsShoot(float damage){
        health -= damage;
        if(health <= 0){ 
            enemyBrain.Die();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            
        }
    }
}
