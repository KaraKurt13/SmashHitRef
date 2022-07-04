using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraTrigger : MonoBehaviour
{
    bool rotateCamera = false;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float destinationAngle;
    private GameObject playerObject;

    void Update()
    {
       if(rotateCamera==true)
        {
            RotatePlayerCamera();
        }
    }

    void RotatePlayerCamera()
    {
        float step = rotateSpeed * Time.deltaTime;
        destinationAngle -= step;
        playerObject.transform.eulerAngles = new Vector3(0, 0, playerObject.transform.eulerAngles.z + step);
        //playerObject.transform.rotation = new Quaternion(0, 0, playerObject.transform.eulerAngles.z + rotateSpeed * Time.deltaTime,1);
        if(destinationAngle<=0)
        {
            rotateCamera = false;
            playerObject.transform.rotation.Normalize();
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Main Camera" && rotateCamera == false)
        {
            playerObject = other.gameObject;
            rotateCamera = true;
        }
    }
}
