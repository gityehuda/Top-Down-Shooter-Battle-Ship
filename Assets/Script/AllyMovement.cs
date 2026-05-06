using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform player;
    private float followDistance = 3f;
    private float moveSpeed = 3f;
    private float distanceToStop = 10f;
    private float fireRate = 1f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Weapon[] weapons;
    private float timeToFire;
    private float rotationSpeed = 1f;

    private Rigidbody2D rb2d;
    private Transform targetEnemy;
    private float nextFireTime;

    enum State { Follow, Attack }
    State state;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        timeToFire = fireRate;              
    }
    Vector2 direction;
    // Update is called once per frame
    void Update()
    {       
        FindNearestEnemy();

        if(targetEnemy == null)
        {
            return;
        }
        else
        {
            direction = targetEnemy.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetEnemy.position, moveSpeed * Time.deltaTime);     
        }
      
        if(Vector2.Distance(targetEnemy.position, transform.position) <=  distanceToStop)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), 5f * Time.deltaTime);
            // Debug.Log("Distance to Stop " + distanceToStop);
            moveSpeed = 0;
            Shoot();
        }
        else
        {
            moveSpeed = 10;
            MovewhileRotating();
        }
    }
    private void FixedUpdate()
    {
      
    }
    void Shoot()
    {
        if (timeToFire <= 0)
        {
            foreach (Weapon weapon in weapons)
            {
                weapon.Fire();
                Debug.Log("Shooted");
            }
          
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDist = Mathf.Infinity;
        Transform closest = null;

        foreach(GameObject e in enemies)
        {
            float distance = Vector2.Distance(transform.position, e.transform.position);    
            if(distance < closestDist)
            {
                closestDist = distance;
                closest = e.transform;              
            }
        }

        targetEnemy = closest;                                                                  

    }

    void MoveForward()
    {
        rb2d.velocity = transform.right * moveSpeed * Time.deltaTime;   
    }

    void MovewhileRotating()
    {
        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg + 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed * Time.deltaTime);
    }

}
