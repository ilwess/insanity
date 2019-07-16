using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    public Vector2 Force = new Vector2(0, 10);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Force, ForceMode2D.Impulse);
        }
    }

    public void SetState(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

    
}
