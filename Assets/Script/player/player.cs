using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float inputX;
    private float inputY;
    private Vector2 movementInput;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Update()
    {
        PlayerInput();
    }
    private void PlayerInput()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        if (inputX != 0 && inputY != 0)
        {
            inputX = Input.GetAxisRaw("Horizontal") * 0.6f;
            inputY = Input.GetAxisRaw("Vertical") * 0.6f;
        }
        movementInput = new Vector2(inputX, inputY);
    }
    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed);
    }
}