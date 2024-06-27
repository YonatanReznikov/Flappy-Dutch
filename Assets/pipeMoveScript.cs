using UnityEngine;

public class pipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 12f;
    public float deadZone = -45f;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Debug.Log("Pipe Deleted");
                Destroy(gameObject);
            }
        }
    }
}
