using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollider : MonoBehaviour
{
    //private BoxCollider solidCollider, triggerCollider;
    private BoxCollider solidCollider;
    private BoxCollider triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider[] colliders = GetComponents<BoxCollider>();
        solidCollider = colliders[0];
        triggerCollider = colliders[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        // solidCollider.enabled = false;
        if (IsPlayer(other) && IsPlayerAbove(other))
        {
            solidCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //solidCollider.enabled = true;
        if (IsPlayer(other))
        {
            solidCollider.enabled = true;
        }
    }

    private bool IsPlayer(Collider other)
    {
        return other.CompareTag("Player");
    }

    private bool IsPlayerAbove(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        return rb != null && rb.velocity.y > 0;
    }
}
