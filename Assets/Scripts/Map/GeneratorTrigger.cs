using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTrigger : MonoBehaviour
{
    public GameObject mapGenerator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mapGenerator.GetComponent<GenerateMap>().IsTrigger();
            foreach (var killer in FindObjectsOfType<WallKiller>())
                killer.StartWall();
        }
    }
}
