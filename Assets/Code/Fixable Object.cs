using UnityEngine;

public class FixableObject : MonoBehaviour
{
    private SpriteRenderer SR;
    public bool Repaired = false;
    private bool Canfix = false;
    public Playermain Playerscript;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Canfix && Input.GetKeyDown(KeyCode.E) && !Repaired)
        {
            Repaired = true;
            Playerscript.Fixed_items++;
        }
        if (Repaired)
        {
            SR.color = Color.orange;
        }
        if (!Repaired)
        {
            SR.color = Color.orangeRed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Canfix = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Canfix = false;
        }
    }
}
