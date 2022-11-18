using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float damage;
    public float speed;
    public float lifeTime;
    private Rigidbody2D rb;
    private EnemyController enemy;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = Vector2.right * speed * Time.deltaTime;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage + (damage * PlayerController.instance.strength));
            Debug.Log("Dealt " + damage + (damage * PlayerController.instance.strength) + " damage to enemy");
            Destroy(gameObject);
        }
    }
}
