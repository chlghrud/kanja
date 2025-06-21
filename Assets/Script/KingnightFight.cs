using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingnightFight : MonoBehaviour
{
    public List<SkillBase> skills = new List<SkillBase>();
    private Animator animator;
    private Vector2 HitBox;
    public Transform hitPos;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        if (Input.GetMouseButton(1) )
        {
            
            animator.SetTrigger("Block");
        }
        if (Input.GetMouseButton(0) )
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HitBox = skills[0].DrawHitBox();
            skills[0].TryExecute(hitPos, animator);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Attack3");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(hitPos.position, HitBox);
    }
}



