using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    private GameManager col;

    private void Start()
    {
        col = FindObjectOfType<GameManager>();
        rb.velocity = new Vector2(speed * Random.Range(-5, 6), speed * Random.Range(-4, 5)) * Time.deltaTime * 20f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Atom")
        {
            rb.velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(speed * Random.Range(-5, 6), speed * Random.Range(-4, 5)) * Time.deltaTime * 20f;
        }
        else if (collision.collider.tag == "Atom2")
        {
            rb.velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(speed * Random.Range(-5, 6), speed * Random.Range(-4, 5)) * Time.deltaTime * 20f;
            try
            {
                col.counter++;
            }
            catch
            {
                // nikog nije briga, hehehe
            }
        }
    }
}