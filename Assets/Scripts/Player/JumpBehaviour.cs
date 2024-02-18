using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpBehaviour : MonoBehaviour
{
    public Rigidbody rb = null;
    public float jumpPower = 10.0f;
    public GroundCheck GroundCheck = null;

    public Animator animator = null;
    public void Jump()
    {
        if (GroundCheck.isgrounded)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
        if (animator != null)
        {
            animator.SetBool("Jump", true);
        }
    }
}
