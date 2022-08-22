using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private SpriteRenderer sr;

    public Weapon weapon;

    public string name_;
    private string description;
    private int rarity;
    private Sprite sprite;
    public float damage;
    public float knockbackForce;
    private BoxCollider2D hitCollider;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public Animator anim;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hitCollider = GetComponent<BoxCollider2D>();
        name_ = weapon.name_;
        description = weapon.description;
        rarity = weapon.rarity;
        sprite = weapon.sprite;
        damage = weapon.damage;
        knockbackForce = weapon.knockbackForce;
        KnockbackController.instance.thrust = weapon.knockbackForce;
        sr.sprite = sprite;
        startTimeBtwAttack = weapon.swingSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timeBtwAttack <= 0f)
            {
                anim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyController>().TakeDamage(damage);
                    KnockbackController.instance.TriggerKnockback(enemiesToDamage[i].GetComponent<Collider2D>());
                }
                //Debug.Log("attacked at " + Time.time);

                timeBtwAttack = startTimeBtwAttack;
            }
        }
        if(timeBtwAttack > 0f)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }

    private void ResetStats()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hitCollider = GetComponent<BoxCollider2D>();
        name_ = weapon.name_;
        description = weapon.description;
        rarity = weapon.rarity;
        sprite = weapon.sprite;
        damage = weapon.damage;
        knockbackForce = weapon.knockbackForce;
        KnockbackController.instance.thrust = weapon.knockbackForce;
        sr.sprite = sprite;
        startTimeBtwAttack = weapon.swingSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
