using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public Text projectilesAmountText;

    [SerializeField] private GameObject gameOverScreen;
    public void SetProjectilesAmountText(int amount)
    {
        projectilesAmountText = transform.Find("Canvas/ProjectilesAmount").GetComponent<Text>();
        projectilesAmountText.text = amount.ToString();
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
