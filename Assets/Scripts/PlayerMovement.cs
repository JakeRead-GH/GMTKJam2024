using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving", true);
            transform.Translate(new Vector3(0.006f, 0, 0), Space.World);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving", true);
            transform.Translate(new Vector3(-0.006f, 0, 0), Space.World);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 4f, 0), ForceMode.Impulse);
        }
        
    }
}
