using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 worldPos;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;


        worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        transform.position = worldPos;
        Debug.Log("mouse position: " + mousePos);


        worldPos.y = 28f;
        Debug.Log("crosshair stays");
    
    }
}
