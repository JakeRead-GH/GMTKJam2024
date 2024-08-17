using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        BoxCollider collider = GetComponent<BoxCollider>();

        animator.SetInteger("Size", newSize);
        switch (newSize)
        {
            case 1:
                collider.size = new Vector3(collider.size.x, 0.53f, collider.size.z);
                break;
            case 2:
                collider.size = new Vector3(collider.size.x, 0.73f, collider.size.z);
                break;
            case 3:
                collider.size = new Vector3(collider.size.x, 1.3f, collider.size.z);
                break;
            case 4:
                collider.size = new Vector3(collider.size.x, 2.35f, collider.size.z);
                break;
            case 5:
                collider.size = new Vector3(collider.size.x, 3.52f, collider.size.z);
                break;

        }


        //GetComponent<Transform>().localScale += new Vector3(1, 0, 1);
    }
}
