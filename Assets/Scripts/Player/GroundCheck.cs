using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundCheck : MonoBehaviour
{
    public bool isgrounded { get; private set; } = true;
    private void OnTriggerEnter(Collider other)
    {
        isgrounded = true;
        Debug.Log("Grounded");
    }
    private void OnTriggerExit(Collider other)
    {
        isgrounded = false;
        Debug.Log("Not Grounded");
    }
}
