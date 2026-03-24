using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        transform.position = transform.position + direction * Time.deltaTime * speed;
    }

    public void setDirection(float x, float y)
    {
        direction.x = x;        
        direction.y = y;                                    
    }

    public void setDirection(Vector2 value)
    {
        direction.x = value.x;
        direction.y = value.y;      
    }

    public void setXDirection(float v)
    {
        direction.x = v;    
    }

    internal void setYDirection(float v)
    {
        direction.y = v;    
    }

    public Vector3 getNextPosition()
    {
        return transform.position + (direction * Time.deltaTime * speed);
    }

}
