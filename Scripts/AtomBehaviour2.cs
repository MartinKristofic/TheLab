using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomBehaviour2 : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    private void Start()
    {
        rb.velocity = new Vector2(speed * Random.Range(-5, 6), speed * Random.Range(-4, 5)) * Time.deltaTime * 20f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Atom" || collision.collider.tag == "Atom2")
        {
            rb.velocity = new Vector2(0, 0);
            rb.velocity = new Vector2(speed * Random.Range(-5, 6), speed * Random.Range(-4, 5)) * Time.deltaTime * 20f;
        }
    }
}
