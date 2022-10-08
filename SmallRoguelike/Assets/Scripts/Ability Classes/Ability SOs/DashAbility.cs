using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class DashAbility : Ability
{
    private float dashSpeed = 10f;
    //AbilityHolder holder = PlayerController.instance.GetComponent<AbilityHolder>();
    public override void Activate()
    {
        PlayerController.instance.speed = dashSpeed;
        PlayerController.instance.anim.SetBool("isDashing", true);
    }
}
