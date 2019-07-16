using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCreatorScript : MonoBehaviour
{
    public float ShadowCoolDown = 6;
    private float shadowCDTimer = 0;

    public GameObject ShadowPrefab;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(shadowCDTimer > 0)
        {
            shadowCDTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R) && shadowCDTimer <= 0)
        {
            shadowCDTimer = ShadowCoolDown;
            GameObject newShadow = Instantiate(ShadowPrefab) as GameObject;
            newShadow.transform.position = gameObject.transform.position;
        }
    }
}
