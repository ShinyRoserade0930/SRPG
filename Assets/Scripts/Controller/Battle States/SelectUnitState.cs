using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUnitState : BattleState
{
    public override void Enter()
    {
        base.Enter();
        StartCoroutine("ChangeCurrentUnit");
    }

    public override void Exit()
    {
        base.Exit();
        statPanelController.HidePrimary();
    }

    IEnumerator ChangeCurrentUnit()
    {
        owner.round.MoveNext();
        SelectTile(turn.actor.tile.pos);
        RefreshPrimaryStatPanel(pos);
        yield return null;
        owner.ChangeState<CommandSelectionState>();
    }
}
