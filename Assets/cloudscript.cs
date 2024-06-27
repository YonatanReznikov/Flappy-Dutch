using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 
    void Update()
    {
        MoveCloud();
    }

    void MoveCloud()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x > 55f)
        {
            Destroy(gameObject);
        }
    }
}
