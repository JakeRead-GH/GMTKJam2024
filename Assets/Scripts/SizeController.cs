using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider[] colliders;
    private SpriteRenderer spriteRenderer;
    private Rigidbody rb;
    public Sprite[] sprites = new Sprite[5];
    public float[] masses = new float[5];

    public float[] SCALE_X = new float[5], SCALE_Y = new float[5];
    public float[] POS_X = new float[5], POS_Y = new float[5];
    private float startingXScale, startingYScale;
    private float startingXPos, startingYPos;

    public float colliderChangeTime = 0.25f;

    private bool isInNoResizeZone = false;

    private int oldSize = 3;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        colliders = GetComponents<BoxCollider>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();

        if (colliders.Length != 0)
        {
            startingXScale = colliders[0].size.x;
            startingYScale = colliders[0].size.y;

            startingXPos = colliders[0].center.x;
            startingYPos = colliders[0].center.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //temp
        if (Input.GetKey(KeyCode.Keypad1))
        {
            ChangeSize(1);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            ChangeSize(2);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            ChangeSize(3);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            ChangeSize(4);
        }
        if (Input.GetKey(KeyCode.Keypad5))
        {
            ChangeSize(5);
        }
    }

    public void ChangeSize(int newSize)
    {
        if (isInNoResizeZone && oldSize < newSize)
        {
            return; // Do not resize
        }

        if (animator != null)
        {
            animator.SetInteger("Size", newSize);
        }
        else
        {
            spriteRenderer.sprite = sprites[newSize - 1];
        }

        if (rb != null)
        {
            rb.mass = masses[newSize - 1];
        }

        foreach (BoxCollider collider in colliders)
        {
            Vector3 targetSize = new Vector3(startingXScale + SCALE_X[newSize - 1], startingYScale + SCALE_Y[newSize - 1], collider.size.z);
            Vector3 targetPos = new Vector3(startingXPos + POS_X[newSize - 1], startingYPos + POS_Y[newSize - 1], collider.center.z);

            StartCoroutine(
                    SmoothColliderScaling(collider, collider.size, collider.center, targetSize, targetPos, colliderChangeTime));
        }

        oldSize = newSize;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NoResizeZone"))
        {
            isInNoResizeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NoResizeZone"))
        {
            isInNoResizeZone = false;
        }
    }

    IEnumerator SmoothColliderScaling(BoxCollider collider, Vector3 initialSize, Vector3 initialPos, Vector3 targetSize, Vector3 targetPos, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            collider.size = Vector3.Lerp(initialSize, targetSize, elapsedTime / duration);
            collider.center = Vector3.Lerp(initialPos, targetPos, elapsedTime / duration);
            yield return null;
        }

        collider.size = targetSize;
        collider.center = targetPos;
    }
}