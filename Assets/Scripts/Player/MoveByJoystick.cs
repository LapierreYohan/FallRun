using UnityEngine;

public class MoveByJoystick : MonoBehaviour
{
    public Joystick joystick = null;
    public float speed = 10.0f;
    public Rigidbody rb = null;
    public Animator animator = null;

    void Update()
    {
        Vector2 inputMouvement = joystick.Direction;

        rb.velocity = new Vector3(inputMouvement.x * speed, rb.velocity.y, inputMouvement.y * speed);

        Vector3 playerPosition = transform.position;
        Vector3 newPlayerPos = new Vector3(playerPosition.x + inputMouvement.x, playerPosition.y ,playerPosition.z + inputMouvement.y);

        if (inputMouvement != Vector2.zero)
        {
            transform.LookAt(newPlayerPos, Vector3.up);
        }

        Debug.DrawLine(playerPosition, newPlayerPos);

        if (animator != null)
        {
            animator.SetFloat("Speed", inputMouvement.magnitude * speed);
            animator.SetBool("Running_jump", false);
            animator.SetBool("Running_slide", false);
        }
    }
}