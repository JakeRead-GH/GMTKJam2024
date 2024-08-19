using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayCollider : MonoBehaviour
{
    private BoxCollider solidCollider, triggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider[] colliders = GetComponents<BoxCollider>();
        solidCollider = colliders[0];
        triggerCollider = colliders[1];
    }

    private void OnTriggerEnter(Collider other)
    {
        solidCollider.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        solidCollider.enabled = true;
    }
}
