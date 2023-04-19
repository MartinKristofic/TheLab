using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block3Script : MonoBehaviour
{
    public float nasumicno;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.attachedRigidbody.velocity = new Vector2(0, 0);

        nasumicno = Random.value; // izmedju 0 i 1 float

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (nasumicno > 0 && nasumicno < 0.49f)
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(-5, 5) * Time.deltaTime * 20f;
            }
            else
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(-5, -5) * Time.deltaTime * 20f;
            }
        }
        else
        {
            collision.collider.attachedRigidbody.velocity = new Vector2(-7, 2) * Time.deltaTime * 20f * gameManager.speedUpFactor;
        }
    }
}
