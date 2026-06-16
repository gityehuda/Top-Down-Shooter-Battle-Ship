using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public bool isPaused;
    private float playerHealth;
    public GameObject gameoverScreen;
    public GameObject missionsuccessScreen;
    public TMP_Text totalEnemyPanel;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Transform TopEnemy;
    [SerializeField] private Transform BottomEnemy;
    // Start is called before the first frame update
    private string sceneName;
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //sceneName = SceneManager.GetActiveScene().name;
        playerHealth = player.GetComponent<PlayerController>().health;
        if(playerHealth <= 0)
        {
            GameOver();
        }
        if(TopEnemy.childCount <= 0  && BottomEnemy.childCount <= 0)
        {
            MissionSuccess();  
        }

        totalEnemyPanel.text = "Destroy All Enemies\n" +
            "Enemies Remaining: " + EnemyCounter();
        if(settingPanel.activeSelf == true)
        {
            PauseGame();            
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

    public void MissionSuccess()
    {

        missionsuccessScreen.SetActive(true);       
    }


    public void PauseCheck()
    {
        
    }

    private float EnemyCounter()
    {
        float bottomenemy = TopEnemy.childCount;
        float topenemy = BottomEnemy.childCount;
        float TotalEnemy = bottomenemy + topenemy;      

        return TotalEnemy;  
    }

}
