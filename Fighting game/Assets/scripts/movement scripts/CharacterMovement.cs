using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform cameraTransform;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Directly capture input from keyboard
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.A))
        {
            horizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontal = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical = -1;
        }

        // Get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Flatten the vectors on the Y axis to ignore camera tilt
        forward.y = 0;
        right.y = 0;

        // Normalize the vectors to ensure consistent movement speed
        forward.Normalize();
        right.Normalize();

        // Create the movement vector relative to the camera
        Vector3 movement = (forward * vertical + right * horizontal);

        // Clamp the movement vector to ensure consistent speed
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Apply movement with speed
        movement *= moveSpeed;

        // Set the Rigidbody velocity to control movement directly
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Log values for debugging
        Debug.Log($"Horizontal Input: {horizontal}, Vertical Input: {vertical}");
        Debug.Log($"Movement Vector: {movement}");
        Debug.Log($"Rigidbody Velocity: {rb.velocity}");
    }
}
