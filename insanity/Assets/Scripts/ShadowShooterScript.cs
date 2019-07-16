using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShooterScript : MonoBehaviour
{
    public GameObject kunaiPrefab;

    public float ShootCD = 1;
    private float shootCDTimer = 0;

    public LayerMask enemyLay = 10;

    private Transform enemyPos = null;
    public float SearchRadius = 5;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        enemyPos = findNearestEnemy(transform.position, SearchRadius, enemyLay);
    }


    void Update()
    {
        if(shootCDTimer > 0)
        {
            shootCDTimer -= Time.deltaTime;
        }
        if(enemyPos != null && shootCDTimer <= 0)
        {
            Debug.Log("ep");
            GameObject newKunai = Instantiate(kunaiPrefab) as GameObject;
            newKunai.transform.position = gameObject.transform.position;
            newKunai.GetComponent<KunaiScript>().SetAim(enemyPos);
            if (this.transform.position.x > enemyPos.position.x)
                transform.Rotate(0, 180, 0);
            shootCDTimer = ShootCD;
        }
    }

    public static Transform findNearestEnemy(Vector2 position, float searchRadius, LayerMask enemyLay)
    {
        Collider2D enemyColider = Physics2D.OverlapCircle(position, searchRadius, enemyLay);
        Transform enemyPos = null;
        if(enemyColider != null)
        {
            enemyPos = enemyColider.transform;
        }
        return enemyPos;
    }
}
