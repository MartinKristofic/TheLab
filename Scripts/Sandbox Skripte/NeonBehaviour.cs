using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonBehaviour : MonoBehaviour
{
    public bool isLit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Nitrogen Gas")
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
