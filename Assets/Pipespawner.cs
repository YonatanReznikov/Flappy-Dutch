using UnityEngine;

public class Pipespawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1.5f;
    private float timer = 0f;
    public float heightoffset = 9f;

    void Start()
    {
        Debug.Log("Pipespawner started with spawn rate: " + spawnRate);
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;
        GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        newPipe.GetComponent<pipeMoveScript>().moveSpeed = logicscript.currentPipeSpeed;
        Debug.Log("Spawned new pipe with speed: " + logicscript.currentPipeSpeed);
    }
}
