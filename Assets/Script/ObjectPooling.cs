using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;
    // [SerializeField] private List<GameObject> pool = new List<GameObject>();
    public ObjectPool<GameObject> pool;
    
    private void Awake()
    {
        instance = this;

        // pool = GeneratePool();
        pool = new ObjectPool<GameObject>(
            () => Instantiate(bulletPrefab, transform)
            , ActionOnGet
            , ActionOnRelease
            , ActionOnDestroy
            , true, poolSize, poolSize * 10
            );
        
        Populate();
    }

    private void ActionOnDestroy(GameObject obj)
    {
        Destroy(obj);
    }

    private void ActionOnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void Populate()
    {
        var temp = new GameObject[poolSize];
        
        for (int i = 0; i < poolSize; i++)
        {
            temp[i] =  pool.Get();    
        }
        
        for (int i = 0; i < poolSize; i++)
        {
            pool.Release(temp[i]);    
        }
    }

    public void Release(GameObject obj)
    {
        pool.Release(obj);
    }
        
    internal GameObject GetObject()
    {
        return pool.Get();
    }

    internal T GetObject<T>()
    {
        return pool.Get().GetComponent<T>();
    }
}
    