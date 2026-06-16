using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Flash,
    Smoke
}

public class PooledEffect : MonoBehaviour
{
    public PoolType poolType;
    public float lifeTime = 0.1f;

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnToPool()
    {
        if(poolType == PoolType.Flash)
        {
            EffectPool.instance.ReleaseFlash(gameObject);   
        }
        else
        {
            EffectPool.instance.ReleaseSmoke(gameObject);   
        }

    }

}
