using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public int damage;
    public Animator animator;
    private float lastUseTime = -Mathf.Infinity;
    

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldown;
    }

    public void TryExecute(Transform origin)
    {
        if (!CanUse()) return;
        animator.SetTrigger(skillName);
        Execute(origin);
        lastUseTime = Time.time;
    }
    public void ResetCooldown()
    {
        lastUseTime = -Mathf.Infinity;
    }
    public abstract Vector2 DrawHitBox();
    public abstract void Execute(Transform origin);
}

