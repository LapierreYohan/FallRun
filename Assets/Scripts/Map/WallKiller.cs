using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKiller : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.forward);
    }
}
