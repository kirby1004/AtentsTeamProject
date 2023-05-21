using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState_Bite : AttackPhase
{
    Transform atkPoint;

    public DragonState_Bite(Dragon dragon) : base(dragon)
    {
        this.atkPoint = dragon.headPoint;
    }

    public override IEnumerator DoPhase()
    {
        float delayTime = 3.0f;
        var wfs = new WaitForSeconds(delayTime);
        while (dragon.myTarget != null)
        {
            if (!dragon.myAnim.GetBool("isAttacking"))
            {
                // playTime 을 nextAttackTime으로 변경 필요
                dragon.playTime += Time.deltaTime;
                if (dragon.playTime >= dragon.AttackDelay)
                {
                    dragon.playTime = 0.0f;
                    dragon.myAnim.SetTrigger("Bite");
                    Debug.Log("물기");
                    dragon.Attack(atkPoint);
                    yield break;
                }
            }
           yield return wfs;
           dragon.playTime += delayTime;
        }
    }
}
