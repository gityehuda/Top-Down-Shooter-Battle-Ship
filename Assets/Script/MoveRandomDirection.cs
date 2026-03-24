using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class MoveRandomDirection : MonoBehaviour
{
    private Moveable mymoveable;
    private void Awake()
    {
        mymoveable = GetComponent<Moveable>();      
    }

    // Start is called before the first frame update
    void Start()
    {
        mymoveable.setDirection(randomDirection(), randomDirection());
    }

    private float randomDirection()
    {
        return Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
