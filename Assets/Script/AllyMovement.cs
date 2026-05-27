using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public enum ShipState
    {
        Formation,
        Attack,
        Evade
    }
    public string allyColumn;
    [Header("Movement")]
    public float moveSpeed = 100f;
    public float rotationSpeed = 40f;
    //  public float acceleration = 2f;
    private float followDistance = 2f;
       
    public FleetLeader leader;
   // public Transform slot;     
    public Transform fleetLeader;
    public float fireRate;
    private float timeToFire;
    public Weapon[] weapons;


    //public float slotFollowStrength = 5f;
    public float combatDistance = 10f;
    //public LayerMask allyLayer;
    //public LayerMask enemyLayer;

    [Header("Avoidance")]
    public float separationRadius = 2f;
    public float separationForce = 3f;
    public float distanceToStop = 40f;

    private Rigidbody2D rb2d;
    private ShipState currentState;

    [SerializeField] private Transform currentEnemy;

    public bool combatMode = false;            

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        currentState = ShipState.Formation;
    }

    void FixedUpdate()
    {
        //CheckCombatState();
        if (combatMode == true)
        {
            CombatMovement();
            Debug.Log("combat mode: active");
        }
        else
        {
            FormationMovement();
        }

    }

    Vector2 direction;
    bool combat = false;
    void CombatMovement()
    {
        //if (currentEnemy == null)
        //    return;

        //Vector2 direction = ((Vector2)currentEnemy.position - rb2d.position).normalized;

        //Vector2 separation = GetSeparationForce();

        //Vector2 finalDirection = (direction + separation).normalized;

        //float angle =
        //    Mathf.Atan2(finalDirection.y, finalDirection.x)
        //    * Mathf.Rad2Deg - 90f;

        //rb2d.rotation =
        //    Mathf.MoveTowardsAngle(
        //        rb2d.rotation,
        //        angle,
        //        rotationSpeed * Time.fixedDeltaTime
        //    );

        //rb2d.velocity = transform.up * moveSpeed;
        if(combat == false)
        {
            rb2d.velocity = Vector2.zero;
            combat = true;
        }
        else
        {
            direction = currentEnemy.position - transform.position;
            transform.position = Vector2.MoveTowards(transform.position, currentEnemy.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(currentEnemy.position, transform.position) <= distanceToStop)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), 5f * Time.deltaTime);
                // Debug.Log("Distance to Stop " + distanceToStop);
                moveSpeed = 0;
                Shoot();
            }
            else
            {

                moveSpeed = 100f;
                RotateTowardTarget();
            }

        }
     
       

    }

    private Vector2 GetSeparationForce()
    {
        Collider2D[] nearby =
        Physics2D.OverlapCircleAll(transform.position, separationRadius);

        Vector2 force = Vector2.zero;

        foreach (Collider2D col in nearby)
        {
            if (col.gameObject == gameObject)
                continue;

            
                Vector2 away =
                    (Vector2)(transform.position - col.transform.position);

                float distance = away.magnitude;

                if (distance > 0.01f)
                {
                    force += away.normalized / distance;
                }
            
        }

        return force * separationForce;
    }

    //private void MoveToSlot()
    //{
    //    Vector2 avoidForce = GetSeparationForce();

    //    Vector2 finalTarget =
    //        targetPosition +
    //        avoidForce * separationForce;

    //    Vector2 dir =
    //        (finalTarget - rb2d.position).normalized;

    //    float angle =
    //        Vector2.SignedAngle(
    //            transform.up,
    //            dir
    //        );

    //    float rotateAmount =
    //        Mathf.Clamp(
    //            angle,
    //            -rotationSpeed * Time.fixedDeltaTime,
    //            rotationSpeed * Time.fixedDeltaTime
    //        );

    //    rb2d.MoveRotation(
    //        rb2d.rotation + rotateAmount
    //    );

    //    rb2d.velocity =
    //        transform.up * moveSpeed;
    //}

    void FormationMovement()
    {
        Vector2 followPos =
         (Vector2)fleetLeader.position -
         (Vector2)fleetLeader.up * followDistance;

        // Direction to follow position
        Vector2 dir = followPos - (Vector2)transform.position;

        // Rotate smoothly
        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRot =
            Quaternion.Euler(0, 0, angle);

        transform.rotation =
            Quaternion.Slerp(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.fixedDeltaTime
            );

        // Move forward
       // rb2d.velocity = transform.up * moveSpeed;
       rb2d.MovePosition(rb2d.position + (Vector2) transform.up * moveSpeed * Time.fixedDeltaTime);    

    }

    void RotateShip(Vector2 direction)
    {
        float rotateAmount = Vector3.Cross(transform.up, direction).z;
        rb2d.angularVelocity = rotateAmount * rotationSpeed;       
    }

    //void CheckCombatState()
    //{
    //    Collider2D enemy = Physics2D.OverlapCircle(transform.position, combatDistance, enemyLayer);
    //    if(enemy != null)
    //    {
    //        combatMode = true;  
    //        currentEnemy = enemy.transform;                     
    //    }

    //}
    private void RotateTowardTarget()
    {
        Vector2 targetDirection = currentEnemy.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }

    private void Shoot()
    {
        if (timeToFire <= 0)
        {
            foreach (Weapon weapon in weapons)
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

}
