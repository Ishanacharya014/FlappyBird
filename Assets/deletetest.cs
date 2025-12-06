using UnityEngine;

public class DeadzoneTester : MonoBehaviour
{
    void OnDrawGizmos()
    {
        if (Camera.main == null) return;

        float H = Camera.main.orthographicSize;
        float W = H * Camera.main.aspect;

        float leftEdge = Camera.main.transform.position.x - W;

        Gizmos.color = Color.magenta;

        // Draw a vertical line at the left edge of the screen
        Gizmos.DrawLine(
            new Vector3(leftEdge, Camera.main.transform.position.y - H, 0),
            new Vector3(leftEdge, Camera.main.transform.position.y + H, 0)
        );
    }
}
