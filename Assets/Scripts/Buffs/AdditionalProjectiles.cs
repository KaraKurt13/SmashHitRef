using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalProjectiles : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private int additionalProjectilesAmount;
    bool objectIsTouched;
    private Player playerController;
    
    void Start()
    {
        objectIsTouched = false;
        playerController = playerObject.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Projectile>() != null && objectIsTouched == false)
        {
            objectIsTouched = true;
            Debug.Log("!!!!!");
            playerController.projectilesAmount += 5;
            playerController.interfaceController.SetProjectilesAmountText(playerController.projectilesAmount);
            Destroy(this.gameObject);
        }
    }

}
