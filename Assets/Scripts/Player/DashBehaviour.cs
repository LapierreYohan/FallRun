using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float dashPower = 10f;
    public float dashDuration = 0.5f;
    public WallCheck wallCheck;
    public Transform orientation;

    private bool isDashing = false;

    void Start()
    {
        Button button = GetComponent<Button>();
        Debug.Log("Button attached to DashBehaviour START !");
        if (button != null)
        {
            button.onClick.AddListener(PerformDash);
            Debug.Log("Button attached to DashBehaviour !");
        }
        else
        {
            Debug.LogError("Le script doit être attaché à un GameObject avec un composant Button.");
        }
    }

    void PerformDash()
    {
        if (!isDashing && !wallCheck.iswalled)
        {
            Debug.Log("Dash !");
            isDashing = true;
            Vector3 vector3 = new Vector3(orientation.forward.x, 0, orientation.forward.z);
            Debug.Log("Dash vector3 : " + vector3);
            playerRigidbody.velocity = vector3 * dashPower;

            Debug.Log("Dash direction : " + orientation.forward);
            Debug.Log("Dash power : " + dashPower);

            // Désactive la gravité et les mouvements du joueur pendant le dash
            playerRigidbody.useGravity = false;
            playerRigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

            Invoke("EndDash", dashDuration);
        }
        else
        {
            Debug.Log("Already dashing or walled !");
        }
    }

    void EndDash()
    {
        Debug.Log("End of dash !");
        isDashing = false;
        playerRigidbody.useGravity = true;
        playerRigidbody.constraints = RigidbodyConstraints.None;
    }
}