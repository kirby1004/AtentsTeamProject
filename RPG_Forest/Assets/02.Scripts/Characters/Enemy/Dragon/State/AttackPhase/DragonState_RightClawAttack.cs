using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonState_RightClawAttack : AttackPhase
{
    Transform atkPoint;

    public DragonState_RightClawAttack(Dragon dragon) : base(dragon) 
    {
        this.atkPoint = dragon.rightClawPoint;
    }

    public override IEnumerator DoPhase()
    {
        float delayTime = 2.0f;
        var wfs = new WaitForSeconds(delayTime);
        while (dragon.myTarget != null)
        {
            if (!dragon.myAnim.GetBool("isAttacking"))
            {
                dragon.playTime += Time.deltaTime;
                if (dragon.playTime >= dragon.AttackDelay)
                {
                    dragon.playTime = 0.0f;
                    dragon.myAnim.SetTrigger("RightAttack");
                    Debug.Log("�����Ȱ���");
                    dragon.Attack(atkPoint);
                    yield break;
                }
            }
            yield return wfs;
            dragon.playTime += delayTime;
        }
    }

}
