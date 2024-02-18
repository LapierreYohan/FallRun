using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaKiller : MonoBehaviour
{
    public GameManager gameManager = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            gameManager.ResetGame();
        }
    }
}
