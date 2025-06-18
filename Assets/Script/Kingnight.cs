using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kingnight : MonoBehaviour
{
    public int MaxHp = 100;
    private int Hp;
    private Animator animator;
    public SkillCollTime Block = new SkillCollTime(1f);
    private SkillCollTime Attack1 = new SkillCollTime(0.5f);
    private SkillCollTime Attack2 = new SkillCollTime(0.5f);
    private SkillCollTime Attack3 = new SkillCollTime(1f);
    void Start()
    {
        animator = GetComponent<Animator>();
        Hp = MaxHp;
    }

 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && Block.CanUse())
        {
            Block.Use();
            animator.SetTrigger("Block");
        }
        if (Input.GetKeyDown(KeyCode.A) && Attack1.CanUse())
        {
            Attack1.Use();
            animator.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.S) && Attack2.CanUse())
        {
            Attack2.Use();
            animator.SetTrigger("Attack2");
        }
        if (Input.GetKeyDown(KeyCode.R) && Attack3.CanUse())
        {
            Attack3.Use();
            animator.SetTrigger("Attack3");
        }
    }
    public void Hit(int damage)
    {
        Hp = Mathf.Clamp(Hp - damage, 0, MaxHp);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}

public class SkillCollTime
{
    private float Cooltime = 0f;
    private  float lastUseTime = -Mathf.Infinity;

    public SkillCollTime(float Cooltime)
    {
        this.Cooltime = Cooltime;
    }
    
    public void Use()
    {
        lastUseTime = Time.time;
    }
    public bool CanUse()
    {
        return Time.time >= lastUseTime + Cooltime;
    }
}