using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern : MonoBehaviour
{
    public List<BaseAbilityPicker> pickers;
    int index;

    public void Pick(PlanOfAttack plan)
    {
        pickers[index].Pick(plan);
        index++;
        if (index >= pickers.Count)
            index = 0;
    }
}
