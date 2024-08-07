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

        // Calculate the desired position based on the player's position and the offset
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

        // Handle camera rotation based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

        verticalRotation -= mouseY * rotationSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f); // Clamp vertical rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, transform.eulerAngles.y, 0);
    }
}
