using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBehaviour : MonoBehaviour
{
    private float walkSpeed = 2;
    private float runSpeed = 4;

    private bool isIdle = true;
    private bool isRun = false;
    private bool isWalk = false;

    private bool isRight = true;

    private Animator animator;

    public LayerMask enemyLayer = 9;
    private float searchRadius = 4;

    private Transform enemy;

    public float Damage = 2;
    private float damageCD = 2;
    private float damageCDTimer = 0;


    private void FixedUpdate()
    {
        enemy = ShadowShooterScript.findNearestEnemy(transform.position, searchRadius, enemyLayer);
        if(enemy != null)
        {
            isIdle = false;
            isRun = true;
            isWalk = false;
        }
        if(enemy == null)
        {
            isIdle = true;
            isRun = false;
            isWalk = false;
        }
        animator?.SetBool("isIdle", isIdle);
        animator?.SetBool("isRun", isRun);
        animator?.SetBool("isWalk", isWalk);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(damageCDTimer > 0)
        {
            damageCDTimer -= Time.deltaTime;
        }
        if (isRun)
        {
            if (enemy)
            {
                if ((enemy.position.x < this.transform.position.x) && isRight)
                {
                    transform.Rotate(0, 180, 0);
                    isRight = !isRight;
                }
                if ((enemy.position.x > this.transform.position.x) && !isRight)
                {
                    transform.Rotate(0, -180, 0);
                    isRight = !isRight;
                }
                transform.Translate(runSpeed * Time.deltaTime, 0, 0);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && (damageCDTimer <= 0))
        {
            Debug.Log("1");
            damageCDTimer = damageCD;
            HealthScript hs = collision.gameObject.GetComponent<HealthScript>();
            if (hs)
            {
                Debug.Log("2");
                hs.DoDamage(Damage);
            }
        }
    }
}
