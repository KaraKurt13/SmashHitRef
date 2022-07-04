using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorObstacle : ObstacleObject
{
    public override void HitReaction()
    {
        GetComponent<Rigidbody>().useGravity = true;
        Destroy(GetComponent<HingeJoint>());
        //GetComponent<HingeJoint>().useMotor=false;
        //GetComponent<HingeJoint>().anchor = new Vector3(0,0,0);
        GetComponent<ObstacleObject>().enabled = false;
    }
}
