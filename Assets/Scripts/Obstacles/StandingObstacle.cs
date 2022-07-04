using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingObstacle : ObstacleObject
{
    public override void HitReaction()
    {
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ObstacleObject>().enabled = false;
    }
}
