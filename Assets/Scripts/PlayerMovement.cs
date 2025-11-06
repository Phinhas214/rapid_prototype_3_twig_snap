using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public float maxSpeed = 5f;
    public float dampingFactor = 0.9f;  // closer to 1 = more slippery, closer to 0 = more friction

    void FixedUpdate()
    {
        Vector3 force = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            force.z += speed;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            force.z -= speed;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            force.x += speed;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            force.x -= speed;

        rb.AddForce(force, ForceMode.Force);

        // Clamp top speed
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

        // custom drag damping
        rb.linearVelocity *= dampingFactor;
    }
}