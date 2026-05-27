using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FleetLeader : MonoBehaviour
{
    public GameObject[] allies;
    public string column;
    public float moveSpeed = 2f;
    public float rotationSpeed = 20f;
    public Transform targetPoint;
    private Rigidbody2D rb2d;
    private List<AllyMovement> allyMovement = new List<AllyMovement>();
    private List<GameObject> columnAllies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        allies = GameObject.FindGameObjectsWithTag("Ally");
        foreach (GameObject go in allies)
        {
            allyMovement.Add(go.GetComponent<AllyMovement>());     
        }
        if(column == "Lee")
        {
            foreach(AllyMovement allyMovement in allyMovement)
            {
                if(allyMovement.allyColumn == "LeeColumn")
                {
                    columnAllies.Add(allyMovement.gameObject);          
                }
            }
        }

        if (column == "Weather")
        {
            foreach (AllyMovement allyMovement in allyMovement)
            {
                if (allyMovement.allyColumn == "WeatherColumn")
                {
                    columnAllies.Add(allyMovement.gameObject);
                }
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targetPoint == null)
        {
            return; 
        }
        float distance = Vector2.Distance(transform.position, targetPoint.position);        
          Debug.Log("distance: " + distance);          


        if(distance < 10f && column == "Lee")
        {
                     
            rb2d.velocity = transform.up * moveSpeed;
            rb2d.angularVelocity = 0f;
            foreach(GameObject collumnallies in columnAllies)
            {
                collumnallies.GetComponent<AllyMovement>().combatMode = true;
            }
            Debug.Log("reached point");
            return;                     
        }

        if (distance < 10f && column == "Weather")
        {

            rb2d.velocity = transform.up * moveSpeed;
            rb2d.angularVelocity = 0f;
            foreach (GameObject collumnallies in columnAllies)
            {
                collumnallies.GetComponent<AllyMovement>().combatMode = true;
            }
            Debug.Log("reached point");
            return;
        }

        Vector2 direction = ((Vector2)targetPoint.position - rb2d.position).normalized;
        float rotationAmount = Vector3.Cross(transform.up, direction).z;
        rb2d.angularVelocity = rotationAmount * rotationSpeed;
        rb2d.velocity = transform.up * moveSpeed;      
    }

    void MoveFleet()
    {
             

        
    }

}
