using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class JumpBehaviour : MonoBehaviour
{
    public Rigidbody rb = null;
    public float jumpPower = 10.0f;
    public GroundCheck GroundCheck = null;

    public void Jump()
    {
        if (GroundCheck.isgrounded)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }

}
