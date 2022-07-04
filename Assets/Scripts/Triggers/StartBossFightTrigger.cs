using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBossFightTrigger : MonoBehaviour
{
    public Player playerController;
    private MoveObjectTrigger moveTrigger;
    [SerializeField] private HeartShield heartShield;

    private bool triggerIsActivated;

    void Start()
    {
        moveTrigger = GetComponent<MoveObjectTrigger>();
        triggerIsActivated = false;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && triggerIsActivated == false)
        {
            DisablePlayerMovementAndIncreaseProjectileSpeed();
            moveTrigger.triggerIsActivated = true;
            heartShield.enabled = true;
        }
    }

    private void DisablePlayerMovementAndIncreaseProjectileSpeed()
    {
        playerController.cameraMoveSpeed = 0;
        playerController.moveSpeedBoost = 0;
        playerController.projectileSpeed = 2300;
        playerController.projectilesAmount += 40;
    }

    
}
