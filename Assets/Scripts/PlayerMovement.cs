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

        if (Input.GetKey(KeyCode.W))
            force.z += speed;
        if (Input.GetKey(KeyCode.S))
            force.z -= speed;
        if (Input.GetKey(KeyCode.D))
            force.x += speed;
        if (Input.GetKey(KeyCode.A))
            force.x -= speed;

        rb.AddForce(force, ForceMode.Force);

        // Clamp top speed
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

        // custom drag damping
        rb.linearVelocity *= dampingFactor;
    }
}