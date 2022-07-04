using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSphere : MonoBehaviour
{
    private GameObject heartShield;
    public FightController fightController;

    public float sphereSpeed;

    private void Start()
    {
        heartShield = transform.parent.gameObject;
        sphereSpeed = 20f;
    }
    void Update()
    {
        transform.RotateAround(heartShield.transform.position, Vector3.up, sphereSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("!!!!");
        
        heartShield.GetComponent<HeartShield>().sphereList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        heartShield.GetComponent<HeartShield>().DicreaseShieldHP();
    }
}
