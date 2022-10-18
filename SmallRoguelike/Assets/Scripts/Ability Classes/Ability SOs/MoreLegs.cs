using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MoreLegs : Ability
{
    private float speed = 1.5f;
    public override void Activate()
    {
        PlayerController.instance.speed = speed + (PlayerController.instance.level / 10f);
    }
}
