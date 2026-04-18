using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxhealth = 10;
    [SerializeField] private Image healthImage;
    private float currentHealth;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //}  

    void Start()
    {
        currentHealth = maxhealth;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth--;
            Debug.Log("enemy hit");
        }
    }

    void Update()
    {
        healthImage.fillAmount = currentHealth / maxhealth;
        float enemyHealth = healthImage.fillAmount;
        healthImage.transform.position = transform.position;
        healthImage.transform.rotation = Camera.main.transform.rotation;                                                
        Debug.Log("current health: " + enemyHealth);
        if(currentHealth == 0)
        {
            Destroy(gameObject);                                
        }  
    }
}
