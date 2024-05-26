using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;
    public float normalSpeed = 1.5f;
    public float sprintSpeed = 3.0f;
    private bool isRunning;

    Rigidbody2D rigidbody2d;

    Animator animator;
    private Vector2 movement;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = normalSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Look X", movement.x);
            animator.SetFloat("Look Y", movement.y);
            animator.SetBool("isMove", true);
        }

        else
        {
            animator.SetBool("isMove", false);
        }
    }
    void FixedUpdate()
    {
        speed = isRunning ? sprintSpeed : normalSpeed;

        rigidbody2d.MovePosition(rigidbody2d.position + movement * speed * Time.fixedDeltaTime);
    }
}