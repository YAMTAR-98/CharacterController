using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRigidbody;
    public float bulletSpeed = 10f;
    public GameObject bulletImpact;

    private void Awake() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start() {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

    }
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<TargetHealth>() != null){
            Debug.Log("Target hit");
            other.GetComponent<TargetHealth>().IsShoot(25f);
            Destroy(gameObject);
        }else if(other.gameObject.tag == "Enviroments"){
            Destroy(gameObject);
        }
        else{
            Debug.Log("Miss");
        }
    }
    private void OnDestroy() {
        Instantiate(bulletImpact, transform.position, Quaternion.identity);
    }
}
