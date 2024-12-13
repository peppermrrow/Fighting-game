using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public Vector3 offset; // Offset from the player position
    public float rotationSpeed = 5f; // Speed of camera rotation

    private float verticalRotation = 0f; // Current vertical rotation

    void LateUpdate()
    {
        if (player == null) return;

        // Set the camera position directly based on the player's position and the offset
        transform.position = player.position + offset;

        // Handle camera rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Horizontal rotation (around Y-axis)
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        // Vertical rotation (around X-axis) with clamping
        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f); // Clamp vertical rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.eulerAngles.y, 0);
    }
}