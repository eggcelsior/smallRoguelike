using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingerShot : Ability
{
    private Transform target;
    public PlayerBulletController bullet;

    public override void Activate()
    {
        switch (level)
        {
            case 1:
                //Spawn the stinger bullet projectile and make it fly in the direction of the closest enemy
                target = LevelManager.instance.GetEnemy(PlayerController.instance.transform);
                var direction = PlayerController.instance.transform.position - target.position;
                Instantiate(bullet, PlayerController.instance.transform.position, Quaternion.LookRotation(direction));
                break;
        }
    }
}
