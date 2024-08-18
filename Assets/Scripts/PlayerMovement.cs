using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    private Animator animator;

    private float moveSpeed, jumpHeight;

    private Vector2 moveInput;

    public bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        moveSpeed = 2f;
        jumpHeight = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.Normalize();

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving", true);
            //transform.Translate(new Vector3(0.006f, 0, 0), Space.World);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving", true);
            //transform.Translate(new Vector3(-0.006f, 0, 0), Space.World);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            moveInput.x = 0;
            animator.SetBool("Moving", false);
        }

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, rb.velocity.z);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump == true)
        {
            canJump = false;
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    }
}
