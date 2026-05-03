using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    private float currentHealth;
    private float maxHealth;
    [SerializeField] private TMP_Text healthPercentage;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if(sceneName == "Gabbard" || sceneName == "Trafalgar")
        {
            maxHealth = GetComponent<PlayerController>().health;
        }
        else
        {
            maxHealth = GetComponent<PlayerController1>().health;                       
        }
       
    }
         
    // Update is called once per frame
    void Update()
    {
        if (sceneName == "Gabbard" || sceneName == "Trafalgar")
        {
            currentHealth = GetComponent<PlayerController>().health;
        }
        else
        {
            currentHealth = GetComponent<PlayerController1>().health;
        }
        healthImage.fillAmount = currentHealth / maxHealth;
        float playerHealth = healthImage.fillAmount;
        healthPercentage.text = currentHealth.ToString() + "%";
          
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            healthPercentage.text = "0%";
        }
    }
}
