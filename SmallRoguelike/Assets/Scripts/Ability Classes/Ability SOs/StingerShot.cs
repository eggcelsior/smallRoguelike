using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerShot : Ability
{
    private Transform target;

    public override void Activate()
    {
        switch (level)
        {
            case 1:
                //Spawn the stinger bullet projectile and make it fly in the direction of the closest enemy
                break;
        }
    }
}
