using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTrigger : MonoBehaviour
{
    public GameObject mapGenerator;
    public GameObject wallKiller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mapGenerator.GetComponent<GenerateMap>().IsTrigger();
            wallKiller.GetComponent<WallKiller>().StartWall();
        }
    }
}
