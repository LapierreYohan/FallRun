using UnityEngine;

public class MoveByJoystick : MonoBehaviour
{
    public Joystick joystick = null;
    public float speed = 10.0f;
    public Rigidbody rb = null;

    void Update()
    {
        Vector2 inputMouvement = joystick.Direction;

        rb.velocity = new Vector3(inputMouvement.x * speed, rb.velocity.y, inputMouvement.y * speed);
    }
}