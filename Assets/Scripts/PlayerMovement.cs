using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer spRender;

    [SerializeField]
    float movementSpeed;


    private Rigidbody2D rig;
    private Animator _anim;

    [SerializeField]
    private float attackRate;
    private float lastAttack;

    //bounds
    //private Vector3 bottomLimit;
    // private Vector3 topLimit;

    float xInput;
    float yInput;
    Vector2 movement;

    [Header("Shooting")]

    [SerializeField]
    private float _fireRate = .5f;

    private float _timePassed;

    [SerializeField]
    int maxAmmo = 15;

    [SerializeField]
    int currentAmmo = 0;

    bool isFiring;

    [SerializeField]
    private GameObject gObject;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float shotSpeed = 1000f;


    // facing sprite direction
    Vector2 direction;

    private void Awake()
    {

    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        if (rig == null)
        {
            Debug.Log("Find the component... or add one");
        }

        spRender = GetComponentInChildren<SpriteRenderer>();
        if (spRender == null)
        {
            Debug.Log("Find the component... or add one");
        }


        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.Log("Find the component... or add one");
        }


    }
    private void FixedUpdate()
    {
        rig.velocity = movement * movementSpeed;

    }


    private void Update()
    {

        if (currentAmmo < 0)
        {
            currentAmmo = 0;
        }

        Movement();
        if (Input.GetKeyDown(KeyCode.M) && Time.time > _timePassed && (_anim.GetFloat("moveX") != 0f || _anim.GetFloat("moveY") != 0))
        {
            Shoot();

        }

    }


    void Movement()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        movement = new Vector2(xInput, yInput).normalized;

        if (movement.x != 0 || movement.y != 0)
        {
            _anim.SetFloat("moveX", movement.x);
            _anim.SetFloat("moveY", movement.y);

            _anim.SetBool("isWalking", true);

        }

        else
        {

            _anim.SetBool("isWalking", false);
        }
        float decreaseTime = Time.time - lastAttack;

        if (Input.GetKeyDown(KeyCode.Space) && decreaseTime > attackRate)
        {
            lastAttack = Time.time;
            _anim.SetTrigger("Hit Target");
        }



    }
    void Shoot()
    {
        isFiring = true;
        _timePassed = Time.time + _fireRate;
        currentAmmo--;
        if (currentAmmo > 0)
        {

            GameObject gObj = Instantiate(gObject, shootPoint.transform.position, shootPoint.transform.rotation);

            

            
            if (_anim.GetFloat("moveX") == -1)
            {
                Instantiate(gObj, -shootPoint.right, Quaternion.identity);
            }
            if (_anim.GetFloat("moveX") == 1)
            {
                Instantiate(gObj, shootPoint.right, Quaternion.identity);
            }
            if (_anim.GetFloat("moveY") == 1)
            {
                Instantiate(gObj, shootPoint.up, Quaternion.identity);
            }
            if (_anim.GetFloat("moveY") == -1)
            {
                Instantiate(gObj, -shootPoint.up, Quaternion.identity);
            }
            
        }
        else if (currentAmmo <= 0 && isFiring)
        {
            isFiring = false;

        }


    }




}