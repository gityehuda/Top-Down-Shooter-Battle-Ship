using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(MyMoveable))]
public class MoveRandom : MonoBehaviour
{
    private MyMoveable moveable;

    // Start is called before the first frame update
    private void Awake()
    {
        moveable = GetComponent<MyMoveable>();
    }

    // Update is called once per frame
    void Start()
    {
        moveable.setDirection(randomDirection(), randomDirection());
    }

    private float randomDirection()
    {
        return Random.Range(-1f, 1f);
    }
}
