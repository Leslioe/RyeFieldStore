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
    private Animator[] animators;
    public bool isMoVing;
    public bool inputDisable;
    private void OnEnable()
    {
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.movePosition += OnMoveToPosition;
        EventHandler.afterSceneUnloadEvent += OnAfterSceneLoadEvent;
    }
    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.afterSceneUnloadEvent -= OnAfterSceneLoadEvent;
        EventHandler.movePosition -= OnMoveToPosition;
    }
    private void OnBeforeSceneUnloadEvent()
    {
        inputDisable = true;
    }
    private void OnMoveToPosition(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }

    private void OnAfterSceneLoadEvent()
    {
        inputDisable = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animators = GetComponentsInChildren<Animator>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Update()
    {
        if (inputDisable == false)
        {
            PlayerInput();
            SwitchAnimator();
        }

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            inputX = inputX * 0.5f;
            inputY = inputY * 0.5f;
        }
        movementInput = new Vector2(inputX, inputY);
        isMoVing = movementInput != Vector2.zero;
    }
    private void Movement()
    {
        rb.MovePosition(rb.position + movementInput * speed);
    }
    private void SwitchAnimator()
    {
        foreach (var anim in animators)
        {
            anim.SetBool("isMoving", isMoVing);
            if (isMoVing)
            {
                anim.SetFloat("InputX", inputX);
                anim.SetFloat("InputY", inputY);
            }
        }
    }

}
