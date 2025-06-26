using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Dash : SkillBase
{
    public override Vector2 DrawHitBox()
    {
        return new Vector2();
    }

    public override void Execute(Transform origin)
    {
    }
}
