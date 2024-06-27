using UnityEngine;

public class FlyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicscript logic;
    public bool robinIsAlive = true;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && robinIsAlive && Time.timeScale == 1)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 17.56f || transform.position.y < -5.73f)
        {
            logic.gameOver();
            robinIsAlive = false;
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        logic.gameOver();
        robinIsAlive = false;
    }
}
