using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]
public abstract class SkillBase : ScriptableObject
{
    public string skillName;
    public float cooldown;
    public int damage;
    private float lastUseTime = -Mathf.Infinity;

    public bool CanUse()
    {
        return Time.time >= lastUseTime + cooldown;
    }

    public void TryExecute(Transform origin, Animator animator)
    {
        if (!CanUse()) return;

        lastUseTime = Time.time;
        Execute(origin, animator);
    }
    public abstract Vector2 DrawHitBox();
    public abstract void Execute(Transform origin, Animator animator);
}

