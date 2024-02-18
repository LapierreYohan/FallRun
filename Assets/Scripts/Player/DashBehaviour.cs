using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{

    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;
    public WallCheck WallCheck = null;

    [Header("Sliding")]
    public float dashForce;
    public float dashTime;

    private float t;
    private Vector3 forceToApply;
    private Vector3 start;
    private Vector3 end;
    private bool isDashing = false;
    private float dashTimer = 0f;

    private void Update()
    {
        if (isDashing)
        {
            Debug.Log("Dashing");
            if (dashTimer <= dashTime && !WallCheck.iswalled)
            {
                Debug.Log("Dashing2");
                rb.position = Vector3.Lerp(start, end, t += 0.1f * Time.deltaTime);
                dashTimer += Time.deltaTime;
                
            }
            else
            {
                Debug.Log("Not Dashing2");
                dashTimer = 0f;
                t = 0f;
                isDashing = false;
                start = Vector3.zero;
                end = Vector3.zero;
                forceToApply = Vector3.zero;
            }
        }
        else
        {
            Debug.Log("Not Dashing");
        }
    }

    public void Dash()
    {
        Debug.Log("Dash");

        isDashing = true;
        start = rb.position;
        forceToApply = orientation.forward * dashForce;
        end = start + forceToApply;

    }
}
