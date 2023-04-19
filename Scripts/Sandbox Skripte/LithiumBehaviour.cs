using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LithiumBehaviour : MonoBehaviour
{
    public GameObject mainLi;

    public ParticleSystem litExplosion1;
    public ParticleSystem litExplosion2;

    public GameObject LiSimbol;
    public GameObject threeNum;

    public SpriteRenderer lithium;
    public BoxCollider2D boxLi;

    private void Start()
    {
        InvokeRepeating("CheckTagStatus", 10f, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fire")
        {
            litExplosion1.Play();

            mainLi.tag = "Exploded";

            Invoke("Play2ndEffect", 0.7f);
            Invoke("SelfDestruct", 1.5f);
        }
    }

    private void SelfDestruct()
    {
        Destroy(mainLi);
    }

    private void Play2ndEffect()
    {
        litExplosion2.Play();

        LiSimbol.SetActive(false);
        threeNum.SetActive(false);

        lithium.enabled = false;
        boxLi.enabled = false;
    }

    void CheckTagStatus() // svake 3 sekunde provjerava ako je litij eksplodirao, a proces eksplozije nije pokrenut
    {
        if (mainLi.tag == "Exploded")
        {
            litExplosion1.Play();

            Invoke("Play2ndEffect", 0.7f);
            Invoke("SelfDestruct", 1.5f);
        }
    }
}
