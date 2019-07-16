using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiScript : MonoBehaviour
{
    public float Speed = 3;

    private float lifeTime = 5;

    void Start()
    {
    }

    
    void Update()
    {
        if (lifeTime > 0)
            lifeTime -= Time.deltaTime;
        else
            Destroy(this.gameObject);
        transform.Translate(new Vector2(Speed*Time.deltaTime, 0));
    }

    public void SetAim(Transform aim)
    {
        if ((transform.position.x - aim.position.x) > 0)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    public void SetAim(bool isRight)
    {
        if (!isRight)
            transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EKnight")
        {
            Destroy(this.gameObject);
            HealthScript healthScript;
            healthScript = collision.gameObject.GetComponent<HealthScript>();
            healthScript?.DoDamage(1f);
        }
    }
}
