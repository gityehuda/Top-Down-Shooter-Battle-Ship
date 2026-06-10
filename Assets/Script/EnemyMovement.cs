using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State{
    Chase,
    Broadside
}



[RequireComponent(typeof(Moveable))]
public class EnemyMovement : MonoBehaviour
{
    State currentState;
    private float moveSpeed = 3f;
    public Transform player;
    public Weapon[] weapons;
    [SerializeField] private Detection detector;
    //private Rigidbody2D rb2d;
   // private Moveable mymoveable;      

    public float distanceToFire = 5f;
    public float distanceToStop = 10f;
    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;
    //  public GameObject bulletPrefab; 
    public float rotationSpeed = 0.1f;
    private float sideDistance = 5f;
    private float detectionRadius = 70f;
    public LayerMask allyLayer;
    float side = 1f;
    public Transform currentAllyOrPlayer;
    private Quaternion previousRotation;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Chase;
        //rb2d = GetComponent<Rigidbody2D>(); 
         player = GameObject.FindGameObjectWithTag("Player").transform;
      //  mymoveable = GetComponent<Moveable>();
        timeToFire = fireRate;  
    }
    Vector2 direction;
    private float dist;
    // Update is called once per frame
    void Update()
    {
     
        if (player != null)
        {
          dist = Vector2.Distance(transform.position, player.transform.position);
           // Debug.Log("distance" + dist);
        }

       // Debug.Log("current distance: " + Vector2.Distance(player.position, transform.position));
        if(currentAllyOrPlayer != null)
        {
            float distanceToAlly = Vector2.Distance(currentAllyOrPlayer.position, transform.position);
            Debug.Log("distance to ally: " + distanceToAlly);
            //  moveSpeed = 4f;
            direction = currentAllyOrPlayer.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, currentAllyOrPlayer.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(currentAllyOrPlayer.position, transform.position) <= distanceToStop)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);       
                // Debug.Log("Distance to Stop " + distanceToStop);
                moveSpeed = 0;
              //  Shoot();       
            }
            else
            {
                currentState = State.Chase;         
                moveSpeed = 4f;
                RotateTowardTarget();
            }
           
        }
        else
        {
            currentAllyOrPlayer = FindNearbyEnemy();    
        }
      
      
    }

    private void FixedUpdate()
    {
       // rb2d.velocity = transform.up * moveSpeed;
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
            foreach(Weapon weapon in weapons)
            {
                weapon.Fire();
            }                                           
          //  Debug.Log("Shooted");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;       
        }
    }

    private void RotateTowardTarget()      
    {
        Vector2 targetDirection = currentAllyOrPlayer.position - transform.position; 
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed * Time.deltaTime);
    }

    private void RotatetoChasePlayer()
    {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private Transform FindNearbyEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D enemy in enemies)
        {
            //Debug.Log("Ally: " + enemy);          
            if (enemy.tag == "Player" || enemy.tag == "Ally")
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            
            }

          
        }

        return closestEnemy;
    }

}
