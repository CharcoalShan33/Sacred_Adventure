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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        HandleMovement();
    }

    private void HandleMovement()
    {
        rb.velocity = new Vector3(xInput, yInput, 0f) * playerSpeed;
    }
}
