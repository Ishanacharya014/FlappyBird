using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud;
    public float spawnRate = 2f;
    public bool gameStarted = false;
    private float timer = 0f;

    void Update()
    {
        if (!gameStarted) return;

        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    void SpawnCloud()
    {
        Camera cam = Camera.main;

        float randomTopY = Random.Range(0.75f, 0.95f);
        // clouds will spawn in the top 25% of the screen

        Vector3 spawnPos = cam.ViewportToWorldPoint(new Vector3(
            1.1f,          // off-screen to the right
            randomTopY,    // always top area
            10f            // distance from camera so conversion works
        ));
        spawnPos.z = 0f;

        Instantiate(cloud, spawnPos, Quaternion.identity);
    }

    public void StartSpawning()
    {
        gameStarted = true;
        timer = 0;
    }
}
