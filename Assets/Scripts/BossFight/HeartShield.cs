using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShield : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private Material activatedShield;
    [SerializeField] private Material brokenShield;


    public int shieldHP;
    public bool shieldIsActivated;
    private bool sphereSpawnIsAvaible;

    private MeshRenderer shieldRenderer;

    public List<GameObject> sphereList;

    

    void Start()
    {
        shieldRenderer = GetComponent<MeshRenderer>();
        shieldRenderer.material = activatedShield;
        shieldIsActivated = true;
        sphereSpawnIsAvaible = true;
        shieldHP = 3;
        sphereList = new List<GameObject>();
    }

    void Update()
    {
        if (sphereSpawnIsAvaible == true && sphereList.Count < 5 && shieldIsActivated == true)
        {
            StartCoroutine(SpawnSphere());
        }
    }

    IEnumerator SpawnSphere()
    {
        sphereSpawnIsAvaible = false;
        GameObject newSphere = Instantiate(spherePrefab, transform, false);
        newSphere.transform.localPosition += new Vector3(1, 0, 0);
        sphereList.Add(newSphere);
        yield return new WaitForSeconds(5);
        sphereSpawnIsAvaible = true;
    }

   
    

    public void DicreaseShieldHP()
    {
        shieldHP--;
        if(shieldHP==0)
        {
            BrokeShield();
        }
    }
    public void BrokeShield()
    {
        GetComponent<SphereCollider>().enabled = false;
        shieldRenderer.material = brokenShield;
        shieldIsActivated = false;
        DestroySpheres();
        StartCoroutine(RestoreShield());
    }

    private void IncreaseSpheresSpeed()
    {
        spherePrefab.GetComponent<ShieldSphere>().sphereSpeed += 15;
    }
    private void DestroySpheres()
    {
        foreach (GameObject sphere in sphereList)
        {
            Destroy(sphere);
        }
        sphereList.Clear();
    }

    IEnumerator RestoreShield()
    {
        yield return new WaitForSeconds(3);
        shieldIsActivated = true;
        shieldRenderer.material = activatedShield;
        shieldHP = 3;
    }

    

    
}
