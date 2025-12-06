using UnityEngine;

public class CloudTestSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            float randomY = Random.Range(0f, 1f);

            Vector3 pos = Camera.main.ViewportToWorldPoint(
                new Vector3(1.1f, randomY, 0)
            );
            pos.z = 0;

            Instantiate(cloudPrefab, pos, Quaternion.identity);
        }
    }
}
