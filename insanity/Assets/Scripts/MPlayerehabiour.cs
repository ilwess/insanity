using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlayerehabiour : MonoBehaviour
{
    public float Velocity = 4;
    private bool isRight = true;

    private Animator animator;

    public Transform groundCheck;
    private bool isJump = false;
    public LayerMask groundLayer;

    private JumpScript js;


    void Start()
    {
        animator = GetComponent<Animator>();
        js = GetComponent<JumpScript>() as JumpScript;
    }

    
    void Update()
    {
        isJump = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        js.SetState(!isJump);
        animator.SetBool("isJump", isJump);
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            animator.SetBool("isRun", false);
        if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Velocity * Time.deltaTime, 0, 0);
            if (isRight) {
                transform.Rotate(0, -180, 0);
                isRight = !isRight;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Velocity * Time.deltaTime, 0, 0);
            if (!isRight) { 
                transform.Rotate(0, 180, 0);
                isRight = !isRight;
            }
        }

    }

    public bool GetDir()
    {
        return isRight;
    }
}
