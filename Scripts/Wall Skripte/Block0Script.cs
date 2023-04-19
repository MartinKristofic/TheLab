using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block0Script : MonoBehaviour
{
    private float nasumicno;
    [SerializeField] HeatSliderScript hsc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.attachedRigidbody.velocity = new Vector2(0, 0);

        if (hsc.slider.value != 0)
        {
            nasumicno = Random.value; // izmedju 0 i 1 float

            if (nasumicno > 0 && nasumicno < 0.49f)
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(5, 5) * Time.deltaTime * 20f;
            }
            else
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(-5, 5) * Time.deltaTime * 20f;
            }
        }
    }
}
