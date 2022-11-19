using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public float cooldownTime;
    public float activeTime;

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState state = AbilityState.ready;

    void Update()
    {
        if (ability != null && !ability.alwaysActive)
        {
            switch (state)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(ability.key) || ability.autoFire)
                    {
                        ability.Activate();
                        state = AbilityState.active;
                        activeTime = ability.activeTime;
                    }
                    break;
                case AbilityState.active:
                    if (activeTime > 0)
                    {
                        activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = AbilityState.cooldown;
                        cooldownTime = ability.cooldownTime;
                    }
                    break;
                case AbilityState.cooldown:
                    if (cooldownTime > 0)
                    {
                        cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        state = AbilityState.ready;
                    }
                    break;
            }
        }
        else if(ability != null)
        {
            ability.Activate();
        }
    }
}
