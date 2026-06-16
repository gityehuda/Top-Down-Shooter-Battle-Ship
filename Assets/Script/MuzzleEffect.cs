using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EffectPool : MonoBehaviour
{
    public static EffectPool instance;

    public GameObject flashPrefab;
    public GameObject smokePrefab;

    private ObjectPool<GameObject> flashpool;
    private ObjectPool<GameObject> smokepool;

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        flashpool = new ObjectPool<GameObject> (
            CreateFlash,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPoolObject, false, 20, 100);

        smokepool = new ObjectPool<GameObject>(
            CreateSmoke,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPoolObject,false, 20, 100);            
    }

    GameObject CreateFlash()
    {
        GameObject obj = Instantiate(flashPrefab);  
        obj.SetActive(false);

        PooledEffect pooledEffect = obj.GetComponent<PooledEffect>();

        pooledEffect.poolType = PoolType.Flash;

        return obj;
    }

    GameObject CreateSmoke()
    {
        GameObject obj = Instantiate(smokePrefab);
        obj.SetActive(false);   
        PooledEffect pooledEffect = obj.GetComponent<PooledEffect>();
        pooledEffect.poolType= PoolType.Smoke;          
        return obj;         
    }

    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }
    
    void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);   
    }

    public GameObject GetFlash()
    {
        return flashpool.Get();
    }

    public GameObject GetSmoke()
    {
        return smokepool.Get();                 
    }

    public void ReleaseFlash(GameObject obj)
    {
        flashpool.Release(obj); 
    }

    public void ReleaseSmoke(GameObject obj)
    {
        smokepool.Release(obj);     
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}
