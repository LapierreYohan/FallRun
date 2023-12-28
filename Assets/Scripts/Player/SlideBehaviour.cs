using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliding : MonoBehaviour {

    [Header("References")]
    public Transform orientation;
    public Rigidbody rb;

    [Header("Sliding")]
    public float slideForce;
    public float slideTime;

    private float t;
    private Vector3 forceToApply;
    private Vector3 start;
    private Vector3 end;
    private bool isSliding = false;
    private float slideTimer = 0f;

    private void Update()
    {
        if (isSliding) {
            if (slideTimer <= slideTime)
            {
                rb.position = Vector3.Lerp(start, end, t += 0.1f * Time.deltaTime);
                slideTimer += Time.deltaTime;
                Debug.Log("Dashing");
            }else
            {
                slideTimer = 0f;
                t = 0f;
                isSliding = false;
                start = Vector3.zero;
                end = Vector3.zero;
                forceToApply = Vector3.zero;
                Debug.Log("Not Dashing");
            }
        }
    }

    public void Slide()
    {
        isSliding = true;
        start = rb.position;
        forceToApply = orientation.forward * slideForce;
        end = start + forceToApply;

        Debug.Log("Dash");
        
    }
}
