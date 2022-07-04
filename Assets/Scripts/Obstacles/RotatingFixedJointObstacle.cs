using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFixedJointObstacle : ObstacleObject
{
    public override void HitReaction()
    {
        Destroy(GetComponent<FixedJoint>());
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ObstacleObject>().enabled = false;
    }
}
