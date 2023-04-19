using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityScript : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Neon")
        {
            gameManager.touchingNeon++;
            collision.GetComponent<NeonBehaviour>().isLit = true;
            collision.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Neon")
        {
            gameManager.touchingNeon--;
            collision.GetComponent<NeonBehaviour>().isLit = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.transform.position.x > 200)
        {
            gameManager.touchingNeon = 0;
        }
    }

}
