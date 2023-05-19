using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState_Create : State
{
    public MonsterState_Create(Monster monster, StateMachine stateMachine) : base(monster, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        monster.OnCreate();
        monster.StartCoroutine(CreateDelay());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    IEnumerator CreateDelay()
    {
        var wfs = new WaitForSeconds(5.0f);
        yield return wfs;
        if(stateMachine.CurrentState == monster.m_states[Monster.eState.Create]) stateMachine.ChangeState(monster.m_states[Monster.eState.Idle]);
    }

}
