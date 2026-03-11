using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Transform[] background;
    public float speed;

    [Header("Posisi Y di atas kamera")]
    public float topPosY;

    [Header("Posisi Y di bawah kamera")]
    public float bottomPosY;                                


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PositionUpdate();
        CheckPosition();                    
    }

    private void CheckPosition()
    {
        if (background[0].position.y < bottomPosY)
        {
            background[0].position = new Vector3(0, topPosY, 0);
        }
        if(background[1].position.y < bottomPosY)
        {
            background[1].position = new Vector3(0, topPosY, 0);
        }

    }

    private void PositionUpdate()
    {
        var movement = Time.deltaTime * speed;
        background[0].position = new Vector3(0, background[0].position.y - movement, 0);
        background[1].position = new Vector3(0, background[1].position.y - movement, 0);
    }
}
