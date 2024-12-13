using UnityEngine;

public class visualizehitbox : MonoBehaviour
{
    private BoxCollider[] boxes; // Declare the array properly

    private void Update()
    {
        boxes = GetComponents<BoxCollider>(); // Get all BoxCollider components
        if (boxes != null && boxes.Length > 0)
        {
            VisualizeBoxCollider(boxes); // Call visualization method for all BoxColliders
        }
    }

    private void VisualizeBoxCollider(BoxCollider[] boxes)
    {
        foreach (BoxCollider box in boxes)
        {
            // Create a new GameObject and LineRenderer for each BoxCollider
            GameObject lineObject = new GameObject("HitboxVisualizer");
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

            // Set up the LineRenderer properties
            lineRenderer.positionCount = 16; // 16 points for a 3D box  
            lineRenderer.startWidth = 0.05f; // Line width
            lineRenderer.endWidth = 0.05f;
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = Color.green; // Line color
            lineRenderer.endColor = Color.green;

            // Get the collider's center in local space and the size
            Vector3 localCenter = box.center;
            Vector3 size = box.size;

            // Calculate the 8 corners of the BoxCollider in local space
            Vector3[] localCorners = new Vector3[8];
            localCorners[0] = new Vector3(-size.x, -size.y, -size.z) / 2;
            localCorners[1] = new Vector3(size.x, -size.y, -size.z) / 2;
            localCorners[2] = new Vector3(size.x, -size.y, size.z) / 2;
            localCorners[3] = new Vector3(-size.x, -size.y, size.z) / 2;
            localCorners[4] = new Vector3(-size.x, size.y, -size.z) / 2;
            localCorners[5] = new Vector3(size.x, size.y, -size.z) / 2;
            localCorners[6] = new Vector3(size.x, size.y, size.z) / 2;
            localCorners[7] = new Vector3(-size.x, size.y, size.z) / 2;

            // Transform the collider's center to world space
            Vector3 worldCenter = box.transform.TransformPoint(localCenter);

            // Transform the corners into world space using the object's transform
            Vector3[] worldCorners = new Vector3[8];
            for (int i = 0; i < localCorners.Length; i++)
            {
                // Add the center offset to the local corner and transform to world space
                worldCorners[i] = box.transform.TransformPoint(localCorners[i] + localCenter);
            }

            // Set the positions of the LineRenderer to the collider's corners in world space
            lineRenderer.SetPositions(new Vector3[]
            {
                worldCorners[0], worldCorners[1], worldCorners[2], worldCorners[3], worldCorners[0], // Bottom
                worldCorners[4], worldCorners[5], worldCorners[6], worldCorners[7], worldCorners[4], // Top
                worldCorners[0], worldCorners[4], // Vertical lines (connecting top and bottom)
                worldCorners[1], worldCorners[5],
                worldCorners[2], worldCorners[6],
                worldCorners[3], worldCorners[7]
            });
        }
    }
}