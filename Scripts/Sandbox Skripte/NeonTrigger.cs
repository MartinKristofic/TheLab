using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonTrigger : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject electricity;
    public GameObject neon;
    private int collCounter;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        electricity = GameObject.FindGameObjectWithTag("Electricity");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Neon")
        {
            collCounter++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) // ova funkcija je puna pokusaja fixanja bugova :D, cilj je provjera ako se neon sudara s ostalim neonom koji svijetli
    {
        if (collision.tag == "Neon" && gameManager.touchingNeon == 0)
        {
            neon.GetComponent<SpriteRenderer>().color = Color.gray;
            neon.GetComponent<NeonBehaviour>().isLit = false;
        }
        else if (collision.tag == "Neon" && collision.GetComponent<NeonBehaviour>().isLit && gameManager.touchingNeon > 0 && electricity.transform.position.x < 200f)
        {
            neon.GetComponent<SpriteRenderer>().color = Color.red;
            neon.GetComponent<NeonBehaviour>().isLit = true;
        }
        else if (collision.tag == "Neon" && electricity.transform.position.x > 200f)
        {
            neon.GetComponent<SpriteRenderer>().color = Color.gray;
            neon.GetComponent<NeonBehaviour>().isLit = false;
        }
        else if (collision.tag == "Neon" && collision.GetComponent<NeonBehaviour>().isLit)
        {
            neon.GetComponent<SpriteRenderer>().color = Color.gray;
            neon.GetComponent<NeonBehaviour>().isLit = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Neon")
        {
            collCounter--;
        }

        if (collCounter == 0)
        {
            neon.GetComponent<SpriteRenderer>().color = Color.gray;
            neon.GetComponent<NeonBehaviour>().isLit = false;
        }
    }
}
