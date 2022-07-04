using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovingObstacle : ObstacleObject
{
    [SerializeField] private Vector3 pointToMove;
    [SerializeField] private float step;
    public bool triggerIsActivated;

    void Start()
    {
        triggerIsActivated = false;
    }

    void Update()
    {
        if(triggerIsActivated==true)
        {
            MoveObstacle();
        }
    }

    public override void HitReaction()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ObstacleObject>().enabled = false;
    }

    public void MoveObstacle()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, pointToMove, step * Time.deltaTime);
    }
}
