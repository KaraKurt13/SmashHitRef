using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMoveSpeedTrigger : MonoBehaviour
{
    private bool triggerIsActivated;
    [SerializeField] private float newCameraMoveSpeed;
    [SerializeField] private float newProjectileSpeed;

    void Start()
    {
        triggerIsActivated = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && triggerIsActivated == false)
        {
            triggerIsActivated = true;
            other.gameObject.GetComponent<Player>().cameraMoveSpeed = newCameraMoveSpeed;
            other.gameObject.GetComponent<Player>().projectileSpeed = newProjectileSpeed;
        }
    }
}
