using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<PlayerMovement>().canJump = true;
    }
}
