using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float maxHealt = 10f;
    private float Health;
    private Animator animator;
    private Collider2D collider;

    void Start()
    {
        Health = maxHealt;
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }
    public void Damage(float f)
    {
        Health = Mathf.Clamp(Health - f, 0, maxHealt);
        
        if (Health == 0)
        {
            Dath();
        }
        else
        animator.SetTrigger("Damage");
    }

    private void Dath()
    {
        animator.SetTrigger("Death");
        collider.enabled = false;
    }

    void Update()
    {
        
    }
}
