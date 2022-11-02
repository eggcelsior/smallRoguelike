using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private bool showGizmo;
    [Header("Stats")]
    public float health;
    public float defense;
    public float damage;
    public float speed;

    private SpriteRenderer sr;
    public Animator anim;
    public GameObject canvas;
    public bool isBeingKnockedBack;
    
    public bool runTowards;

    private Rigidbody2D rb;
    private Vector2 direction;
    private bool damagingPlayer = false;
    public float damagePlayerInterval;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        canvas.SetActive(true);
        //anim.Play("EnemyAmogus_Spawn", 0);
    }

    // Update is called once per frame
    void Update()
    {
        StateSelector();
    }
    public void TakeDamage(float damage)
    {
        SoundManager.instance.PlaySound(0);
        //CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f); Probably shouldn't do this due to the amount of enemies that will exist and be getting damaged at once.
        health -= damage - defense;
        damage -= defense;
        if (damage <= 0)
        {
            damage = 0.5f;
        }
        if (health <= 0f)
        {
            //play animation and maybe change this to a coroutine 
            SoundManager.instance.PlaySound(3); 
            Destroy(gameObject);
        }
    }
    private void StateSelector()
    {
        if (!isBeingKnockedBack)
        {
            if (runTowards)
            {
                direction = PlayerController.instance.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = direction * speed;
                if (sr.isVisible)
                {
                    //anim.SetBool("isMoving", true);
                }

            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            damagingPlayer = true;
            Debug.Log("Trigger Entered");
            StartCoroutine(damagePlayer(damage));
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "player")
        {
            damagingPlayer = false;
        }
    }
    public IEnumerator damagePlayer(float damage)
    {
        if (damagingPlayer)
        {
            PlayerController.instance.TakeDamage(damage);
            Debug.Log("Damaged player " + damage);
            yield return new WaitForSeconds(damagePlayerInterval);
            StartCoroutine(damagePlayer(damage));
        }
        yield return 0;
    }
}
