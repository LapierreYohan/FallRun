using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBehaviour : MonoBehaviour
{
    public Rigidbody rb = null;
    public float jumpPower = 10.0f;
    public GroundCheck GroundCheck = null;

    public void Jump()
    {
        if (GroundCheck.isgrounded)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
}
