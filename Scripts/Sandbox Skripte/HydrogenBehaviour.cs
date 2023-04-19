using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenBehaviour : MonoBehaviour
{
    public GameObject mainH;

    public ParticleSystem HydExplosion;
    public SpriteRenderer hydrogen;
    public GameObject H;
    public GameObject One;
    public BoxCollider2D hydroBox;

    public Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.name == "Fire")
         {
             HydroKaboom();
         }
    }

    private void Murder()
    {
        Destroy(mainH);
    }

    public void HydroKaboom()
    {
        HydExplosion.Play();

        gameObject.tag = "Exploded";

        H.SetActive(false);
        One.SetActive(false);

        hydrogen.enabled = false;
        hydroBox.enabled = false;

        Invoke("Murder", 1.5f);
    }
}
