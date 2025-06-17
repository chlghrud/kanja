using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public GameObject comp;
    public int a;

    private Companion companion;
    private byte pressECount = 0;
    private bool isGrounded = false;
    private float moveX = 0f;
    private SpriteRenderer spriter;
    private Animator animator;
    private Rigidbody2D rb;
    private bool canMove = true;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>(); // spriter 를 가지고온 이유가 flipX 로 왼쪽오른쪽 이동 할 때 반전하려고
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (comp.CompareTag("companion"))
        {
            companion = comp.GetComponent<Companion>();
        }
        else
        {
            Debug.Log("err:companion is null");
        }
    }

    void Update()
    {
        if (companion == null)
            return;

       
        moveX = Input.GetAxis("Horizontal");

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log(isGrounded);
        Debug.Log(groundCheck.position);
        Animation();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && moveX != 0)
        {
            Jump();
        }

    }

    private void LateUpdate()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetTrigger("isJump");
    }

    private void Swap()
    {
        if (pressECount == 0)
        {
            canMove = false;
            companion.fadeIn(spriter.flipX);

            animator.SetTrigger("Parrying");
            animator.SetInteger("mode", UnityEngine.Random.Range(1, 6));
            pressECount++;
        }
        else if (pressECount == 1)
        {
            canMove = true;
            companion.fadeOut();
            pressECount = 0;
            animator.SetInteger("mode", 0);
        }

    }

    private void Animation()
    {
        if (moveX != 0 && canMove)
        {
            spriter.flipX = moveX < 0;
            animator.SetBool("isMove", true);
        }
        else if (animator.GetBool("isMove") && moveX == 0)
        {
            animator.SetBool("isMove", false);
        }
        animator.SetBool("isGround", isGrounded);
        animator.SetBool("Drop", rb.velocity.y < 0);
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

}
