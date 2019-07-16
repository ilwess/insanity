using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float HP = 10;

    public delegate void Die();

    private Die die;

    private void Start()
    {
        die = DefaultDieMethod;
    }

    public void DoDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            die?.Invoke();
        }
    }

    public void SetDieMethod(Die dieMethod)
    {
        this.die = dieMethod;
    }

    private void DefaultDieMethod()
    {
        Destroy(gameObject);
    }
}
