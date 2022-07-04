using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultProjectile : Projectile
{
    private void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObstacleObject>() != null)
        {
            collision.gameObject.GetComponent<ObstacleObject>().HitReaction();
        }
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
