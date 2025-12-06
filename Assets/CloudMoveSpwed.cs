using UnityEngine;

public class CloudMoveSpwed : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float deadzone;

    void Start()
    {
        float H = Camera.main.orthographicSize;
        float W = H * Camera.main.aspect;

        deadzone = Camera.main.transform.position.x - W - 2f; // always off-screen
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadzone)
        {
            Destroy(gameObject);
        }
    }
}
