using UnityEngine;

[CreateAssetMenu(menuName = "Skills/MeleeSkill")]
public class Attack : SkillBase
{
    public LayerMask enemyLayer;
    public Vector2 Hitbox;
    public override Vector2 DrawHitBox()
    {
        return Hitbox;
    }

    public override void Execute(Transform origin, Animator animator)
    {
        animator.SetTrigger(skillName);
        Debug.Log("실2");
        Collider2D[] enemies = Physics2D.OverlapBoxAll(origin.position, Hitbox, enemyLayer);
        foreach (var enemy in enemies)
        {
            if (enemy.gameObject.layer == enemyLayer)
            {
                Debug.Log("실1");
                enemy.GetComponent<HealthController>().Damage(damage);
            }
        }
    }
}

