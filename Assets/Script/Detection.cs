using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    [HideInInspector] public bool isDetected;
    public GameObject detectedObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         isDetected = true;
        if (detectedObject == null)
        {
            detectedObject = collision.gameObject;
        } 
        
    }
}
