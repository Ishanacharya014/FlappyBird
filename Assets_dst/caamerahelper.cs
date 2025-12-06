using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    void Update()
    {
        Camera cam = Camera.main;
        float H = cam.orthographicSize;
        float W = H * cam.aspect;

        // Draw box showing camera bounds
        Debug.DrawLine(new Vector3(-W, -H, 0), new Vector3(W, -H, 0), Color.red);
        Debug.DrawLine(new Vector3(W, -H, 0), new Vector3(W, H, 0), Color.red);
        Debug.DrawLine(new Vector3(W, H, 0), new Vector3(-W, H, 0), Color.red);
        Debug.DrawLine(new Vector3(-W, H, 0), new Vector3(-W, -H, 0), Color.red);
    }
}
