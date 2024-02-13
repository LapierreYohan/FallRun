using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallCheck : MonoBehaviour
{
    public bool iswalled { get; private set; } = false;
    private void OnTriggerEnter(Collider other)
    {
        iswalled = true;
        Debug.Log("Walled");
    }
    private void OnTriggerExit(Collider other)
    {
        iswalled = false;
        Debug.Log("Not Walled");
    }
}
