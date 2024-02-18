using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallKiller : MonoBehaviour
{
    public GameManager gameManager = null;
    public float speed = 1;
    bool startMove = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameManager.ResetGame();
        }
    }

    public void StartWall()
    {
        startMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startMove)
        {
            transform.Translate(Time.deltaTime * Vector3.forward * speed);
        }
    }
}
