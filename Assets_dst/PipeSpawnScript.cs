using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 4f;
    public bool gameStarted = false;
    private float timer = 0f;

    public float pipeMoveSpeed = 5f;
    public int pipesSpawned = 0;

    void Update()
    {
        if (!gameStarted) return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        Camera cam = Camera.main;

        float randomMidY = Random.Range(0.3f, 0.7f);
        // Pipes spawn only in middle 40% of screen

        Vector3 spawnPos = cam.ViewportToWorldPoint(new Vector3(
            1.1f,         // spawn just outside right side
            randomMidY,   // safe mid-range
            10f
        ));
        spawnPos.z = 0f;

        GameObject newPipe = Instantiate(pipe, spawnPos, transform.rotation);

        PipeMoveScript pms = newPipe.GetComponent<PipeMoveScript>();
        pms.moveSpeed = pipeMoveSpeed;

        pipesSpawned++;

        if (pipesSpawned >= 10)
        {
            pipeMoveSpeed += 1f;
            spawnRate -= 0.2f;
            if (spawnRate < 0.5f) spawnRate = 0.5f;

            pipesSpawned = 0;
        }
    }
}
