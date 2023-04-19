using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LithiumTrigger : MonoBehaviour
{
    public GameObject mainLi;

    public ParticleSystem litExplosion1;
    public ParticleSystem litExplosion2;

    public GameObject LiSimbol;
    public GameObject threeNum;

    public SpriteRenderer lithium;
    public BoxCollider2D boxLi;

    public bool hasExploded = false;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Exploded" && hasExploded == false)
        {
            hasExploded = true;

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
}
