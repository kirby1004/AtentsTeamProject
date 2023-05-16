using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState_Landing : State
{
    Dragon dragon;
    float offset = 5.0f;

    public DragonState_Landing(Monster monster, StateMachine stateMachine) : base(monster, stateMachine)
    {
        dragon = monster as Dragon;
    }

    public override void Enter()
    {
        base.Enter();
        dragon.StopAllCoroutines();
        dragon.myAnim.SetTrigger("Landing");
        dragon.StartCoroutine(Landing());
    }

    public override void Exit()
    {
        base.Exit();
        dragon.myAnim.SetBool("isFlying", false);
        dragon.isFlying = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    IEnumerator Landing()
    {
        float landTime = 0f;

        Vector3 startPos = dragon.transform.position;
        Vector3 targetPos = dragon.orgPos;

        while (landTime < 1.0f)
        {
            landTime += Time.deltaTime / dragon.landingDuration;
            dragon.transform.position = Vector3.Lerp(startPos, targetPos, landTime);
            yield return null;
        }
        stateMachine.ChangeState(dragon.m_states[Dragon.eState.BattleDragon]);
    }
}
