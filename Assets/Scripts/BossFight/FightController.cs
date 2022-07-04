using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    private bool sphereSpawninAvaible;
    private bool shieldIsActivated;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private GameObject heartShield;

    public List<GameObject> sphereList;
    public int sphereAmountRemain;

    private void Start()
    {
        sphereSpawninAvaible = true;
        sphereAmountRemain = 3;
        shieldIsActivated = heartShield.GetComponent<HeartShield>().shieldIsActivated;
        sphereList = new List<GameObject>();
    }

    private void Update()
    {
        if(sphereSpawninAvaible==true && sphereList.Count<5 && shieldIsActivated==true)
        {
            StartCoroutine(SpawnSphere());
        }
    }

    IEnumerator SpawnSphere()
    {
        sphereSpawninAvaible = false;
        GameObject newSphere = Instantiate(spherePrefab, heartShield.transform,false);
        newSphere.transform.localPosition += new Vector3(1, 0, 0);
        sphereList.Add(newSphere);
        yield return new WaitForSeconds(5);
        sphereSpawninAvaible = true;
    }
}
