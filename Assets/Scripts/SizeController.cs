using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeController : MonoBehaviour
{
    private Animator animator;
    private BoxCollider collider;

    public float[] SCALE_X = new float[5], SCALE_Y = new float[5];
    public float[] POS_X = new float[5], POS_Y = new float[5];
    private float startingXScale, startingYScale;
    private float startingXPos, startingYPos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();

        startingXScale = collider.size.x;
        startingYScale = collider.size.y;

        startingXPos = collider.center.x;
        startingYPos = collider.center.y;
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
        animator.SetInteger("Size", newSize);
        collider.size = new Vector3(startingXScale + SCALE_X[newSize - 1], startingYScale + SCALE_Y[newSize - 1], collider.size.z);
        collider.center = new Vector3(startingXPos + POS_X[newSize - 1], startingYPos + POS_Y[newSize - 1], collider.center.z);
    }
}
