using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float spawnXPosition = -55f;
    [SerializeField] private float minYPosition = 14f;
    [SerializeField] private float maxYPosition = 24f;
    [SerializeField] private float minDistance = 5f;

    private float timer = 0f;
    private float lastSpawnY = 0f;

    void Update()
    {
        HandleCloudSpawning();
    }

    void HandleCloudSpawning()
    {
        if (Time.timeScale == 1)
        {
            timer += Time.deltaTime;

            if (timer >= spawnRate)
            {
                SpawnCloud();
                timer = 0f;
            }
        }
    }

    void SpawnCloud()
    {
        float spawnYPosition = GetValidSpawnYPosition();
        lastSpawnY = spawnYPosition;

        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0);
        Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
    }

    float GetValidSpawnYPosition()
    {
        float spawnYPosition = Random.Range(minYPosition, maxYPosition);

        while (Mathf.Abs(spawnYPosition - lastSpawnY) < minDistance)
        {
            spawnYPosition = Random.Range(minYPosition, maxYPosition);
        }

        return spawnYPosition;
    }
}
