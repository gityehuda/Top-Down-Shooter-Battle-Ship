using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused;
    private float playerHealth;
    public GameObject gameoverScreen;
    // Start is called before the first frame update
    private string sceneName;
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Trafalgar" || sceneName == "Gabbard")
        {
            playerHealth = player.GetComponent<PlayerController>().health;  
        }
        else   
        {
            playerHealth= player.GetComponent<PlayerController1>().health;   
        }
        if(playerHealth <= 0)
        {
            GameOver();
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;    
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;             
        isPaused = false;   
    }

    public void GameOver()
    {
        gameoverScreen.SetActive(true);    
    }

    public void PauseCheck()
    {
        
    }

}
