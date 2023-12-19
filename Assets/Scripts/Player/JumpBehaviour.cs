using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class JumpBehaviour : MonoBehaviour
{
    public Rigidbody rb = null;
    public float jumpPower = 10.0f;
    public GroundCheck GroundCheck = null;

    public InputActionReference clickActionRef = null;
    public LayerMask groudLayer;
    public Joystick joystick = null;


    private void OnFingerDown(EnhancedTouch.Finger finger)
    {
        RectTransform joystikCoord = (joystick.transform as RectTransform);

        if (finger.screenPosition.x > joystikCoord.offsetMin.x && finger.screenPosition.x < joystikCoord.offsetMax.x
                       && finger.screenPosition.y > joystikCoord.offsetMin.y && finger.screenPosition.y < joystikCoord.offsetMax.y)
        {
            return;
        }

        if (GroundCheck.isgrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower);
    }

    void OnEnable()
    {
        clickActionRef.action.performed += OnclickActionRef;
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += OnFingerDown;

    }

    void OnDisable()
    {
        clickActionRef.action.performed -= OnclickActionRef;
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
    }

}
