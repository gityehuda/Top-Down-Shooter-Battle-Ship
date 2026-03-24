using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 4f;
    public Transform player;
    public Weapon weapon;       
   // private Moveable mymoveable;

    public float distanceToFire = 5f;
    public float distanceToStop = 3f;
    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;
  //  public GameObject bulletPrefab; 


    // Start is called before the first frame update
    void Start()
    {
        weapon = transform.GetChild(0).GetComponent<Weapon>();        
       // player = GameObject.FindGameObjectWithTag("Player").transform;
      //  mymoveable = GetComponent<Moveable>();
        timeToFire = fireRate;  
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            moveSpeed = 4f;
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        if (player != null)
        {
            if (Vector2.Distance(player.position, transform.position) <= distanceToStop)
            {
                moveSpeed = 0;
                Shoot();
            }
        
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);    
        }*/
    }

    private void Shoot()
    {
        if(timeToFire <= 0)
        {
            weapon.Fire();
            Debug.Log("Shooted");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;       
        }
    }

}
