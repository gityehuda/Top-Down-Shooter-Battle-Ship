using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }

    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);                                
        }  
    }
}
