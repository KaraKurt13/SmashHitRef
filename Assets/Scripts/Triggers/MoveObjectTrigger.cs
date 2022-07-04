using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToMove;
    [SerializeField] private Vector3 pointToMove;
    [SerializeField] private float step;
    public bool triggerIsActivated;
    private void Start()
    {
        triggerIsActivated = false;
    }

    private void Update()
    {
        if(triggerIsActivated==true)
        {
            MoveObject();
        }
    }
    private void MoveObject()
    {
        objectToMove.transform.localPosition = Vector3.MoveTowards(objectToMove.transform.localPosition, pointToMove, step * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && triggerIsActivated == false)
        {
            triggerIsActivated = true;
        }
    }
}
