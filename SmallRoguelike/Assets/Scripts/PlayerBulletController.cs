using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float damage;
    private float damageMultiplier;
    public float speed;
    public float lifeTime;
    public bool shouldPoint; //Should point towards nearest enemy
    private EnemyController enemy;
    private Transform target;
    private Vector3 path;
    public GameObject child;
    private void Start()
    {
        
        if (shouldPoint)
        {
            target = LevelManager.instance.closestEnemy;
            path = (target.position - transform.position);
            child.transform.Rotate(0,0, Mathf.Atan2(path.y, path.x) * Mathf.Rad2Deg);
            
        }
        ReadyMultipliers();
    }
    private void Update()
    {
        transform.Translate(path * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage); //+ (damage * PlayerController.instance.strength)
            Debug.Log("Dealt " + damage + " damage to enemy");
            Destroy(gameObject);
        }
    }
    private void ReadyMultipliers()
    {
        damageMultiplier = damage;
        damageMultiplier *= PlayerController.instance.strength;
        damage += damageMultiplier;
    }
}
