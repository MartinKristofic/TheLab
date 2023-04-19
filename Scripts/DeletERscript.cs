using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletERscript : MonoBehaviour
{
    // skripta s ciljem unistavanja pobijeglih organizama preko bijele linije

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
