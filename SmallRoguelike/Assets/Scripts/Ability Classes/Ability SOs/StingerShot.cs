using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/Stinger Shot")]
public class StingerShot : Ability
{
    public PlayerBulletController bullet;
    public override void Activate()
    {
        switch (level)
        {
            case 0:
                //Spawn the stinger bullet projectile
                Instantiate(bullet, PlayerController.instance.transform.position, Quaternion.identity);
                break;
        }
    }
}
