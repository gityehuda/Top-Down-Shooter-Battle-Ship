using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 4f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(gameObject.tag == "Bullet" && collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;     
        if(lifeSpan <= 0 )
        {
            Destroy(gameObject);               
        }   

    }
}
