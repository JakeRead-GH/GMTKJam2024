using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0.006f, 0, 0), Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-0.006f, 0, 0), Space.World);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 4f, 0), ForceMode.Impulse);
        }
        
    }
}
