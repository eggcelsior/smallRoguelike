using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackController : MonoBehaviour
{
    public static KnockbackController instance;

    [Header("Knockback Vars")]
    public float knockbackTime;
    public float thrust;

    private void Awake()
    {
        instance = this;
    }

    public void TriggerKnockback(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            EnemyController controller = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                controller.isBeingKnockedBack = true;
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse); //What is forcemode2d
                StartCoroutine(Knockback(enemy, controller));
            }
        }
    }

    private IEnumerator Knockback(Rigidbody2D enemy, EnemyController controller)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            if(enemy != null)
            {
                enemy.velocity = Vector2.zero;
                enemy.isKinematic = true;
                controller.isBeingKnockedBack = false;
            }
        }
    }
}
