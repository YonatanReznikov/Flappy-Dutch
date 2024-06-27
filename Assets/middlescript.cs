using UnityEngine;

public class middlescript : MonoBehaviour
{
    public logicscript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Score")
        {
            logic.addscore(1);
        }
    }
}
