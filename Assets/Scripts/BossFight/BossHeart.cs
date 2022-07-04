using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHeart : MonoBehaviour
{
    private float heartRotationSpeed;
    private int heartHP;

    private MeshRenderer heartRenderer; 

    [SerializeField] private Material defaultHeart;
    [SerializeField] private Material damagedHeart;



    void Start()
    {
        heartRenderer = GetComponent<MeshRenderer>();
        heartRotationSpeed = 10f;
        heartHP = 150;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(heartRotationSpeed * Time.deltaTime, heartRotationSpeed * Time.deltaTime, heartRotationSpeed * Time.deltaTime));

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="DefaultProjectile(Clone)")
        {
            GetDamage();
        }
           
    }

    void GetDamage()
    {
        heartHP -= 5;
        heartRotationSpeed += 5;

        if(heartHP<=0)
        {
            Destroy(transform.parent.gameObject);
        }
        Debug.Log(heartHP);
        StartCoroutine(ChangeTexturelToDamaged());

       
    }

    IEnumerator ChangeTexturelToDamaged()
    {
        heartRenderer.material = damagedHeart;
        yield return new WaitForSeconds(0.1f);
        heartRenderer.material = defaultHeart;
    }
}
