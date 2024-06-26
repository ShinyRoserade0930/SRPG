using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSelectionState : BaseAbilityMenuState
{
    public override void Enter()
    {
        base.Enter();
        statPanelController.ShowPrimary(turn.actor.gameObject);
        if (driver.Current == Drivers.Computer)
            StartCoroutine(ComputerTurn());
    }

    public override void Exit()
    {
        base.Exit();
        statPanelController.HidePrimary();
    }

    protected override void LoadMenu()
    {
        if (menuOptions == null)
        {
            menuTitle = "Commands";
            menuOptions = new List<string>(3);
            menuOptions.Add("Move");
            menuOptions.Add("Action");
            menuOptions.Add("Wait");
        }

        abilityMenuPanelController.Show(menuTitle, menuOptions);
        abilityMenuPanelController.SetLocked(0, turn.hasUnitMoved);
        abilityMenuPanelController.SetLocked(1, turn.hasUnitActed);
    }

    protected override void Confirm()
    {
        switch (abilityMenuPanelController.selection)
        {
            case 0:
                owner.ChangeState<MoveTargetState>();
                break;
            case 1:
                owner.ChangeState<CategorySelectionState>();
                break;
            case 2:
                owner.ChangeState<EndFacingState>();
                break;
        }
    }

    protected override void Cancel()
    {
        if (turn.hasUnitMoved && !turn.lockMove)
        {
            turn.UndoMove();
            abilityMenuPanelController.SetLocked(0, false);
            SelectTile(turn.actor.tile.pos);
        }
        else
        {
            owner.ChangeState<ExploreState>();
        }
    }

    IEnumerator ComputerTurn()
    {
        if (turn.plan == null)
        {
            turn.plan = owner.cpu.Evaluate();
            turn.ability = turn.plan.ability;
        }

        yield return new WaitForSeconds(1f);

        if (turn.hasUnitMoved == false && turn.plan.moveLocation != turn.actor.tile.pos)
            owner.ChangeState<MoveTargetState>();
        else if (turn.hasUnitActed == false && turn.plan.ability != null)
            owner.ChangeState<AbilityTargetState>();
        else
            owner.ChangeState<EndFacingState>();
    }
}
