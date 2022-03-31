using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSR;
    [SerializeField] private Animator playerAnim;
    private Rigidbody2D rb;

    float walkSpeed = 4f;
    float speedLimiter = 0.73f;
    float inputHorizontal;
    float inputVertical;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleFlip();
        HandleAnim();
    }

    private void HandleAnim()
    {
        if (inputHorizontal != 0 || inputVertical !=0)
        {
            playerAnim.Play("Walk");
        }
        else
        {
            playerAnim.Play("Idle");
        }
    }

    private void HandleFlip()
    {
        if (inputHorizontal !=0)
        {
            
            if (!playerSR.flipX && inputHorizontal > 0)
            {
                playerSR.flipX = true;
            }
            else if (playerSR.flipX && inputHorizontal < 0)
            {
                playerSR.flipX = false;
            }
        }
    }

    private void HandleMovement()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }

            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
