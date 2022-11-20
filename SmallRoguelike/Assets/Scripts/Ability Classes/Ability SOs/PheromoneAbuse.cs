using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Abilities/Pheromone Abuse")]
public class PheromoneAbuse : Ability
{
    public float damage;
    //public float damageInterval;
    public float range;
    public LayerMask enemies;

    public override void Activate()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(PlayerController.instance.transform.position, range, enemies);
        PlayerController.instance._PARange = range; // This is for testing
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(damage);
        }
    }
}
