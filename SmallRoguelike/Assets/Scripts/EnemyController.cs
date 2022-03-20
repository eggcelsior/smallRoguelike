﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int health;
    public float shootRange;
    public float maxAggroRange;
    public float minAggroRange;
    public float shootRate;
    public GameObject bullet;
    public Transform firepoint;

    private SpriteRenderer sr;

    [Header("Slider Things")]
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;
    
    [Header("Enemy Type Differentiators")] //Find a way to use an enum for this
    public bool runAndShoot;
    public bool walkTowardsAndBounceOff;

    private Rigidbody2D rb;
    private Vector3 direction;
    private float shootCounter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        slider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        StateSelector();
        HealthBar();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            //play animation and maybe change this to a coroutine
            Destroy(gameObject);
        }
    }
    private void StateSelector()
    {
        if (runAndShoot)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= shootRange)
            {
                shootCounter -= Time.deltaTime;
                if (shootCounter <= 0f)
                {
                    shootCounter = shootRate;
                    Instantiate(bullet, firepoint.position, transform.rotation);
                    //Play sound effect or something idk
                }
            }
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= maxAggroRange &&
                Vector3.Distance(transform.position, PlayerController.instance.transform.position) >= minAggroRange && sr.isVisible) //This should be cleaned up using bools
            {
                direction = PlayerController.instance.transform.position - transform.position;
                direction.Normalize();
                rb.velocity = direction;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        /*if (walkTowardsAndBounceOff)
        {
            
        }*/
    }

    public void HealthBar()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
        slider.gameObject.SetActive(health < slider.maxValue);
        slider.value = health;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxAggroRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minAggroRange);
    }

}