using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterChangeStates : MonoBehaviour
{
    public Rigidbody2D waterRb;

    public ParticleSystem waterParticles;
    public ParticleSystem waterParticles1;
    public ParticleSystem waterParticles2;

    public bool locker = false; // varijable sprijecavanje ponavljanja promjene u isto stanje (S u S)
    public bool locker1 = false;

    public GameObject emptyGO; // varijabla za rijesavanje problema s localnom varijablom i metodom colllision.collider

    public GameObject water;
    public GameObject hydrogen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fire" && locker == false)
        {
            waterParticles.Play();
            waterRb.gravityScale = -0.5f;
            locker = true;
            locker1 = false;
        }
        else if (collision.name == "Nitrogen Gas" && locker1 == false)
        {
            waterParticles1.Play();
            waterRb.gravityScale = 1f;
            locker = false;
            locker1 = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Lithium")
        {
            waterParticles2.Play();

            emptyGO = collision.gameObject; // davanje litija u varijablu emptyGameObject 

            Invoke("SpawnHydrogen", 0.25f);
            Invoke("MurderAndSpawnHydrogen", 0.3f);
        }
    }

    private void SpawnHydrogen()
    {
        Instantiate(hydrogen, water.transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
    }

    private void MurderAndSpawnHydrogen()
    {
        Destroy(emptyGO); // unistenje litija i vode
        Destroy(water);
    }
}
