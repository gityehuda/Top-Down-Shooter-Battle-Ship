using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;

    [SerializeField] private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        instance = this;

        pool = GeneratePool();
        HideAllPoolObjects();
    }

    private void HideAllPoolObjects()
    {
        foreach (GameObject obj in pool)
        {
            obj.SetActive(false);
        }
    }

    private List<GameObject> GeneratePool()
    {
        List<GameObject> pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(bulletPrefab, transform));
        }

        return pool;
    }

    internal GameObject GetInactiveObject()
    {
        foreach(GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        Debug.Log("No pooled object is available right now! Consider expanding the pool size", this);
        return null;
    }
}
<<<<<<< Updated upstream
=======
    
>>>>>>> Stashed changes
