using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Camera cam;
    [Header("Movement Things")]
    public float speed;
    public bool canMove;
    private float normalSpeed;
    private Rigidbody2D rb;
    private Vector2 input = new Vector2();
    public Animator anim;
    public Transform gunArm;

    [Header("Ability Enablers")]
    //Dash Things
    public bool canDash = false;
    private float dashSpeed = 10f;
    private float dashCoolDown = 0.5f;
    private float dashWaitTime = 0f;
    private float dashReset = 0f;
    private float dashTimer;
    private float dashTimerTimer = 2f;
    //


    [Header("Rotation Things")]
    public Vector3 centerPoint;
    private float weaponRotationRadius;
    public Quaternion rotation;

    [Header("Weapon Things")]
    public GameObject weaponTest;
    public float distance;

    //public SpriteRenderer rend;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalSpeed = speed;
        rotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        WeaponMovement();
    }
    private void PlayerMove()
    {
        if (canMove)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            input.Normalize();
            if(input.x < 0)
            {
                rotation.y = 180;
            }
            if(input.x > 0)
            {
                rotation.y = 0;
            }
            transform.localRotation = rotation;
            rb.velocity = input * speed;
            //Debug.Log(input);
            if (input != new Vector2(0,0))
            {
                anim.SetFloat("Speed", 1);
            }
            else
            {
                anim.SetFloat("Speed", -1);
            }
            
            Dashing();
            
        }
    }
    
    private void WeaponMovement()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        centerPoint = transform.position; //position of the player

        Vector3 offset = mousePos - centerPoint;

        weaponTest.transform.position = centerPoint + Vector3.ClampMagnitude(offset, distance);
    }

    private void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashReset <= 0f && dashWaitTime <= 0f && canDash && dashTimer <= 0)
            {
                speed = dashSpeed;
                dashWaitTime = dashCoolDown;
                dashTimer = dashTimerTimer;
                anim.SetBool("isDashing", true);
            }
        }
        if (dashWaitTime > 0)
        {
            dashWaitTime -= Time.deltaTime;
            if (dashWaitTime <= 0)
            {
                anim.SetBool("isDashing", false);
                speed = normalSpeed;
                dashReset = dashCoolDown;
            }
        }
        if (dashReset > 0)
        {
            dashReset -= Time.deltaTime;
        }
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
        }
    }

}
