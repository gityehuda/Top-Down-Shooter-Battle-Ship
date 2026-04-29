using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private int playerHealth;
    public GameObject gameoverScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<PlayerController>().health;  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;                
    }

    public void GameOver()
    {
        gameoverScreen.SetActive(true);    
    }

}
