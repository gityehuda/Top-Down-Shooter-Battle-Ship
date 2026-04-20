using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Moveable))]
public class EnemyMovement1 : MonoBehaviour
{
    State currentState;
    private float moveSpeed = 3f;
    public Transform player;
    public Weapon weapon;
    //private Rigidbody2D rb2d;
   // private Moveable mymoveable;

    public float distanceToFire = 5f;
    public float distanceToStop = 10f;
    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;
    //  public GameObject bulletPrefab; 
    private float rotationSpeed = 0.1f;
    private float sideDistance = 5f;
    float side = 1f;
    private Quaternion previousRotation;
    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Chase;             
        //rb2d = GetComponent<Rigidbody2D>(); 
        weapon = transform.GetChild(0).GetComponent<Weapon>();        
         player = GameObject.FindGameObjectWithTag("Player").transform;
      //  mymoveable = GetComponent<Moveable>();
        timeToFire = fireRate;  
    }
    Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log("distance" + dist);
        if (player != null)
        {
         

          

        }

       // Debug.Log("current distance: " + Vector2.Distance(player.position, transform.position));
        if (player != null && dist <= 50f)
        {
            //  moveSpeed = 4f;
            direction = player.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            //Vector2 sideDirection = new Vector2(-direction.y, -direction.x);
            //Vector2 targetPosition = (Vector2)player.position + sideDirection * side * sideDistance;

            //Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
            //transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

            if (Vector2.Distance(player.position, transform.position) <= distanceToStop)
            {
                //if (currentState == State.Chase)
                //{
                //    previousRotation = transform.rotation;
                //}
                //currentState = State.Broadside;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), 5f * Time.deltaTime);
                // Debug.Log("Distance to Stop " + distanceToStop);
                moveSpeed = 0;
                Shoot();
            }
            else
            {
                //if(currentState == State.Broadside)
                //{
                //    previousRotation = transform.rotation;
                //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, previousRotation.z), 1f * Time.deltaTime);
                //    Debug.Log("rotated1");
                //}
                currentState = State.Chase;         
                moveSpeed = 4f;
                RotateTowardTarget();
            }
           
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
            weapon.Fire();                                  
            Debug.Log("Shooted");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;       
        }
    }

    private void RotateTowardTarget()
    {
        Vector2 targetDirection = player.position - transform.position; 
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private void RotatetoChasePlayer()
    {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
