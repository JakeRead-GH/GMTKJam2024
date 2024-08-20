using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    private Animator gateAnimator;
    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        gateAnimator = GetComponent<Animator>();
        gateAnimator.SetBool("IsOpen", true);
    }

    public void GateOpen()
    {
        collider.enabled = false;
        gateAnimator.SetBool("IsOpen", false);
    }

    public void GateClose() 
    {
        collider.enabled = true;
        gateAnimator.SetBool("IsOpen", true);
    }
}
