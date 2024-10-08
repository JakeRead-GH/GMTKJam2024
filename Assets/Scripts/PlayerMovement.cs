using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioClip[] sfx_steps;
    Rigidbody rb;

    private Animator animator;

    private float moveSpeed, jumpHeight;

    private Vector2 moveInput;

    public bool canJump;

    private bool isMoving = false;
    private Coroutine footstepsCoroutine;

    public GameObject groundCheck;
    public float[] groundCheckOffsets = new float[5];

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        moveSpeed = 3f;
        jumpHeight = 5f;
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
            if (!isMoving)
            {
                isMoving = true;
                footstepsCoroutine = StartCoroutine(PlayFootsteps());
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving", true);
            //transform.Translate(new Vector3(-0.006f, 0, 0), Space.World);
            GetComponent<SpriteRenderer>().flipX = true;
            if (!isMoving)
            {
                isMoving = true;
                footstepsCoroutine = StartCoroutine(PlayFootsteps());
            }
        }
        else
        {
            moveInput.x = 0;
            animator.SetBool("Moving", false);
            if (isMoving)
            {
                isMoving = false;
                StopCoroutine(footstepsCoroutine);
            }
        }

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, rb.velocity.z);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump == true)
        {
            canJump = false;
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            audioSource.Play();
        }
    }

    // This coroutine plays the footstep sound effects while the player is moving
    private IEnumerator PlayFootsteps()
    {
        while (isMoving && canJump)
        {
            SFX_Manager.instance.PlayRandomSFX(sfx_steps, transform, 3f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SetJumpHeight(int height)
    {
        groundCheck.transform.localPosition = new Vector3(groundCheck.transform.localPosition.x, groundCheckOffsets[height - 1], groundCheck.transform.localPosition.z);

        switch (height)
        {
            case 1:
                jumpHeight = 1.5f;
                break;
            case 2:
                jumpHeight = 2.5f;
                break;
            case 3:
                jumpHeight = 5;
                break;
            case 4:
                jumpHeight = 6;
                break;
            case 5:
                jumpHeight = 10;
                break;
            default:
                jumpHeight = 5;
                break;
        }
    }
}
