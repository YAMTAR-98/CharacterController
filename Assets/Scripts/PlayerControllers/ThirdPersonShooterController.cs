using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColiderLayerMask = new LayerMask();
    //[SerializeField] private Transform debugTransform;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private Transform spawnBulletPoint;
    private StarterAssetsInputs starterAssetsInputs;
    private ThirdPersonController thirdPersonController; 
    Animator anim;

    private void Awake(){
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
        Vector3 mouseWorldPosition = Vector3.zero;

        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColiderLayerMask)){
            //debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        if(starterAssetsInputs.aim){
            anim.SetBool("Aim", true);
            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            if(starterAssetsInputs.shoot){
            anim.SetTrigger("Shoot");
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPoint.position).normalized;
            Instantiate(bulletPrefab, spawnBulletPoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
            starterAssetsInputs.shoot = false;
        }
        }else{
            anim.SetBool("Aim", false);
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);

        }
        
        
        
    }
}
