using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float xInput;
    private float yInput;

    [SerializeField]
    private float playerSpeed;

    [SerializeField]
    private float jumpVelocity;

    private bool isGrounded;

    [SerializeField]
    float groundCheckDist;

    [SerializeField]
    LayerMask layer;

    private Animator anim;

    public bool isWalking = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
     
        HandleCollision();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
        HandleAnimation();
         HandleMovement();
        
    }

    

    private void HandleJump()
    {
        

        
    }

    private void HandleAnimation()
    {
       
        anim.SetBool("isWalking", isWalking);
        //anim.SetFloat("xMove", rb.velocity.x);
    }
    private void HandleCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDist, layer);

    }

    private void HandleMovement()
    {
        rb.velocity = new Vector3(xInput, yInput, 0f) * playerSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDist, 0f));
    }
}
