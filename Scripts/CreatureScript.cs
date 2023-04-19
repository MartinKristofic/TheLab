using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureScript : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject creature;
    private Rigidbody2D rb;

    private const int defaultEnergyValue = 100;

    public float speed = 1f;
    public float size = 1f;
    public float energy = 100f; // sposobnost vršenja radnji *wink* *wink*, 100 je default vrijednost, recimo da su u pitanju džuli(J)

    public bool hasEaten;

    private float fixer; // varijabla naijenjena za popravljanje simetrije mjenjanja smjera

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        creature = gameObject;
        rb = creature.GetComponent<Rigidbody2D>();

        hasEaten = false;

        fixer = Random.Range(0.01f, 0.15f);

        gameObject.transform.localScale = new Vector3(0.4f, 0.4f ,1) * size;
        energy = defaultEnergyValue / (speed * size); // formula za energiju u ovoj simulaciji :D, vrlo kreativno, definitivno bolje od E = mc2

        InvokeRepeating("ChangePosition", fixer, 0.5f);
        InvokeRepeating("CreatureColor", fixer, 0.2f);
        InvokeRepeating("WasterEnergy", fixer, 0.1f);
    }

    private void ChangePosition()
    {
        if (gameManager.isAllowedToLive)
        {
            rb.velocity = new Vector2(gameManager.speedUpFactor * speed  * Random.Range(-5, 6), gameManager.speedUpFactor * speed * Random.Range(-4, 5)); // random movement skripta kopirana iz AtomBehaviour.cs skripte
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameManager.isAllowedToLive)
        {
            rb.velocity = new Vector2(gameManager.speedUpFactor * speed * Random.Range(-5, 6), gameManager.speedUpFactor * speed * Random.Range(-4, 5));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food" && gameManager.isAllowedToLive)
        {
            Destroy(collision.gameObject);
            hasEaten = true;
        }
    }

    private void WasterEnergy() // troši energiju, 10 po sekundi deafult, kad padne do?e do nule bi?e umire
    {
        if (gameManager.isAllowedToLive)
        {
            energy = energy - 1 * gameManager.speedUpFactor;
        }

        if (energy <= 0 && !hasEaten)
        {
            Destroy(gameObject);
        }
    }

    public void CreatureColor() // namjerno koristim 4 if, a ne 1 if i 3 else if
    {
        if (0.75f > speed && speed < 1f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0.3995435F, 1);
        }
        if (speed < 0.75f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
        }
        if (1.25f > speed && speed > 1f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0.6170464f);
        }
        if (speed > 1.25)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
}
