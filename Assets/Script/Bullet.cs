using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpanDefault = 1f;
    private float lifeSpan;
    [SerializeField]private ObjectPooling pool;
    private GameObject[] bullets;
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (gameObject.tag == "EnemyBullet" && collision.gameObject.tag == "Player")
       {
            //Destroy(gameObject);
            DeactivateBullet();
       }

        if (gameObject.tag == "Bullet" && collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            DeactivateBullet();      
        }
    

    }

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = lifeSpanDefault;
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0)
        {
            DeactivateBullet();
            lifeSpan = lifeSpanDefault;
        }


    }

    private void DeactivateBullet()
    {
        StartCoroutine(ReturnToPool()); 
    }

    IEnumerator ReturnToPool()
    {  
         gameObject.SetActive(false);
        yield return null;
        
      
    }

}
