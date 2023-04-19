using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBehaviour : MonoBehaviour
{
    [SerializeField] GameObject water;

    [SerializeField] SpriteRenderer mainOxy;
    [SerializeField] GameObject O;
    [SerializeField] GameObject eight;

    [SerializeField] ParticleSystem oxyBurn;
    [SerializeField] ParticleSystem oxyCool;

    private bool isLiquid = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Hydrogen")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

            Instantiate(water, gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fire")
        {
            BurnOxygen();
        }
        else if (collision.name == "Nitrogen Gas")
        {
            if (!isLiquid) 
            {
                CoolOxygen();
            }
        }
    }

    private void CoolOxygen()
    {
        oxyCool.Play();
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        isLiquid = true;
    }

    public void BurnOxygen()
    {
        oxyBurn.Play();

        mainOxy.tag = "Exploded";

        mainOxy.enabled = false;
        mainOxy.GetComponent<BoxCollider2D>().enabled = false;

        O.SetActive(false);
        eight.SetActive(false);

        Invoke("DestroyOxygen", 1.2f);
    }

    private void DestroyOxygen()
    {
        Destroy(gameObject);
    }
}
