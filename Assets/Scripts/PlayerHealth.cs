using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "EnemyHitPoint"){
            health -= 10f;
            if(health <= 0f){
                GetComponent<Animator>().SetBool("Die", true);
            }
        }
    }
}
