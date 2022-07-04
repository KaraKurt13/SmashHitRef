﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVerticalObstacle : ObstacleObject
{
    public float moveSpeed;
    public float distance;
    private Vector3 edgePoint;
    private Vector3 startPoint;

   

    private void Start()
    {
        startPoint = transform.position;
        edgePoint = new Vector3(startPoint.x, startPoint.y + distance, startPoint.z);
    }

    private void Update()
    {
        float step =  moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, edgePoint, step);
        if (Vector3.Distance(transform.position,edgePoint)<0.001f)
        {
            
            distance *= -1;
            edgePoint.y=startPoint.y+distance;
        }
    }

    public override void HitReaction()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ObstacleObject>().enabled = false;
    }
}
