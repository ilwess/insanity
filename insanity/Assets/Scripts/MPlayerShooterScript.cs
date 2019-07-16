using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerShooterScript : MonoBehaviour
{
    public GameObject kunaiPrefab;

    public float ShootCD = 1;
    private float shootCDTimer = 0;

    void Start()
    {

    }

    private void FixedUpdate()
    {
    }


    void Update()
    {
        if (shootCDTimer > 0)
        {
            shootCDTimer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.M) && shootCDTimer <= 0)
        {
            Debug.Log("ep");
            GameObject newKunai = Instantiate(kunaiPrefab) as GameObject;
            newKunai.transform.position = gameObject.transform.position;
            newKunai.GetComponent<KunaiScript>().SetAim(GetComponent<MPlayerehabiour>().GetDir());
            shootCDTimer = ShootCD;
        }
    }
}
