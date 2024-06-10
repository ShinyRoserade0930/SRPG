using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FacingsExtensions
{
    // Might change diagonal definition 
    // FFF
    // SoS
    // BBB
    public static Facings GetFacing(this Unit attacker, Unit target)
    {
        Vector2 targetDirection = target.dir.GetNormal();
        Vector2 approachDirection = ((Vector2)(target.tile.pos - attacker.tile.pos)).normalized;
        float dot = Vector2.Dot(approachDirection, targetDirection);
        if (dot >= 0.7f) // 1 over sqrt 2
            return Facings.Back;
        if (dot <= -0.7f)
            return Facings.Front;
        return Facings.Side;
    }
}
