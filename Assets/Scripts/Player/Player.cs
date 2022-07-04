using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float cameraMoveSpeed;
    public float moveSpeedBoost;
    public float projectileSpeed;
    public int projectilesAmount;
    
    bool gameIsOver;
    bool shootIsAvaible;

    private Touch touch;
    private Camera playerCamera;
    public UIController interfaceController;
    public GameObject playerProjectilePrefab;


    private void Start()
    {
        gameIsOver = false;
        shootIsAvaible = true;
        projectileSpeed = 1000;
        playerCamera = GetComponent<Camera>();
        interfaceController = GetComponent<UIController>();
        interfaceController.SetProjectilesAmountText(projectilesAmount);
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, cameraMoveSpeed * Time.deltaTime));
        cameraMoveSpeed += moveSpeedBoost * Time.deltaTime;
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if ((touch.phase == TouchPhase.Began || touch.phase==TouchPhase.Stationary || touch.phase==TouchPhase.Moved) && shootIsAvaible == true && projectilesAmount != 0)
            {
                StartCoroutine(StartShooting());
            }

        }

    }

    private IEnumerator StartShooting()
    {
        shootIsAvaible = false;
        projectilesAmount -= 1;
        

        interfaceController.SetProjectilesAmountText(projectilesAmount);

        Vector3 projectilePosition = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z + 0.7f);
        GameObject playerProjectile = Instantiate(playerProjectilePrefab, projectilePosition, transform.rotation);

        playerProjectile.transform.LookAt(playerCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, transform.position.z + 130f)));
        playerProjectile.GetComponent<Rigidbody>().AddForce(playerProjectile.transform.forward * projectileSpeed);

        yield return new WaitForSeconds(0.3f);
        shootIsAvaible = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (gameIsOver == false && other.gameObject.GetComponent<ObstacleObject>() != null && other.gameObject.GetComponent<ObstacleObject>().enabled==true)
        {
            gameIsOver = true;
            interfaceController.ShowGameOverScreen();
            cameraMoveSpeed = 0f;
            moveSpeedBoost = 0f;
        }
    }
}
