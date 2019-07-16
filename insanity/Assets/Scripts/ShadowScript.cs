using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public float LifeTime = 6;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(LifeTime > 0)
        {
            LifeTime -= Time.deltaTime;
        }
        if(LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
