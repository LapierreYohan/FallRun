using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject map;

    bool timerIsStart = false;
    float timerTime = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
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
        GameObject mainParent = GameObject.FindWithTag("MAP");
        GameObject newInstance = Instantiate(map);
        Vector3 newPos = new(map.transform.position.x, map.transform.position.y, map.transform.position.z + 50);
        newInstance.name = "floor";
        newInstance.transform.parent = mainParent.transform;
        newInstance.transform.position = newPos;
    }
    private void DestroyMySelf()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
