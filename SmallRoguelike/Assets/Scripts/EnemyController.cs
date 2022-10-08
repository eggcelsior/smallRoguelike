using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private bool showGizmo;
    public float health;
    public float damage;

    private SpriteRenderer sr;
    public Animator anim;
    public GameObject canvas;
    public bool isBeingKnockedBack;
    
    public bool runAndShoot;

    private Rigidbody2D rb;
    private Vector3 direction;
    private bool damagingPlayer = false;
    public float damagePlayerInterval;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        canvas.SetActive(true);
        anim.Play("EnemyAmogus_Spawn", 0);
    }

    // Update is called once per frame
    void Update()
    {
        StateSelector();
    }
    public void TakeDamage(float damage)
    {
        SoundManager.instance.PlaySound(1);
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
        health -= damage;
        if(health <= 0f)
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
            if (runAndShoot)
            {
                direction = PlayerController.instance.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = direction;
                if (sr.isVisible)
                {
                    anim.SetBool("isMoving", true);
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
