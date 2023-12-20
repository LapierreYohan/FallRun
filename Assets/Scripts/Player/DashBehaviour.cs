using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;

    [Header("Settings")]
    public bool disableGravity = false;

    public void Dash()
    {

        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

       rb.AddForce(forceToApply, ForceMode.Impulse);

        if (disableGravity)
            rb.useGravity = false;

        Invoke("ResetDash", dashDuration);

    }

    public void ResetDash()
    {
        
    }
}