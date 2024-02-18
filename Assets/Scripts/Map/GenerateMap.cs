using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    //public GameObject parent = null;
    public GameObject level = null;
    public GameObject waiting = null;

    List<GameObject> maps = new List<GameObject>();

    bool timerIsStart = false;
    float timerTime = 5;

    private void Awake()
    {
        if(level != null && waiting != null)
        {
            maps.Add(level);
            maps.Add(waiting);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerIsStart = true;
        }
    }

    private void Update()
    {
        if (timerIsStart)
        {
            if(timerTime > 0)
            {
                timerTime -= Time.deltaTime;
            }
            else{
                DestroyMySelf();
            }
        }
    }
    public void IsTrigger()
    {
        GameObject parent = gameObject.transform.parent.gameObject;

        int randomNumber = UnityEngine.Random.Range(0, 2);
        GameObject selectedInstance = maps[randomNumber];
        GameObject mainParent = GameObject.FindWithTag("MAP");
        GameObject newInstance = Instantiate(selectedInstance);

        int zPos;
        if (parent.CompareTag("Level") && selectedInstance.CompareTag("Waiting"))
            zPos = 100;
        else if (parent.CompareTag("Level") && selectedInstance.CompareTag("Level"))
            zPos = 100;
        else if (parent.CompareTag("Waiting") && selectedInstance.CompareTag("Level"))
            zPos = 40;
        else
            zPos = 40;

        Vector3 newPos = new(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z + zPos);

        newInstance.name = "floor";
        newInstance.transform.parent = mainParent.transform;
        newInstance.transform.position = newPos;
    }
    private void DestroyMySelf()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
