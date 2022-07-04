using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacleTrigger : MonoBehaviour
{
    bool triggerIsActivated;

    private void Start()
    {
        triggerIsActivated = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && triggerIsActivated == false)
        {
            triggerIsActivated = true;
            transform.parent.GetComponent<TriggerMovingObstacle>().triggerIsActivated = true;
            Destroy(this.gameObject);
        }
    }
}
