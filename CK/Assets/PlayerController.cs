using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSR;
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
            rb.velocity = new Vector2(0,0);
        }
    }
}
