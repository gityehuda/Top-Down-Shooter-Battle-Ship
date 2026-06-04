using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpanDefault = 1f;
    // public ObjectPooling pool;
    
    private float lifeSpan;
    private Rigidbody2D _rigidbody2D;
    // private GameObject[] bullets;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        lifeSpan = lifeSpanDefault;
    }

    void Update()
    {
        lifeSpan -= Time.deltaTime;

        if (!(lifeSpan <= 0)) return;
        
        DeactivateBullet();
        Reset();
    }

    private void Reset()
    {
        lifeSpan = lifeSpanDefault;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
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


    private void DeactivateBullet()
    {
        ObjectPooling.instance.Release(gameObject);
        // StartCoroutine(ReturnToPool()); 
    }

    IEnumerator ReturnToPool()
    {  
         gameObject.SetActive(false);
        yield return null;
        
      
    }

    public void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position =  position;
    }

    public void AddForce(Vector3 velocity)
    {
        _rigidbody2D.AddForce(velocity, ForceMode2D.Impulse);
    }
}
