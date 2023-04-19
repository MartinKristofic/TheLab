using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block1Script : MonoBehaviour
{
    public Slider volume;
    public RectTransform zid;

    public float nasumicno;

    public float startPositionX;

    [SerializeField] HeatSliderScript hsc;

    private void Start()
    {
        startPositionX = zid.transform.position.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.attachedRigidbody.velocity = new Vector2(0, 0);

        nasumicno = Random.value; // izmedju 0 i 1 float

        if(hsc.slider.value != 0)
        {
            if (nasumicno > 0 && nasumicno < 0.49f)
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(5, 5) * Time.deltaTime * 20f;
            }
            else
            {
                collision.collider.attachedRigidbody.velocity = new Vector2(5, -5) * Time.deltaTime * 20f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (zid.position.x < -3 && zid.position.x >= startPositionX)
        {
            zid.position = new Vector3(zid.position.x + (volume.value / 80f), zid.position.y, 0);
        }
        else if (zid.position.x < startPositionX)
        {
            zid.position = new Vector3(zid.position.x + 0.05f, zid.position.y, 0);
            volume.value = 0f;
        }
        else if (zid.position.x > -3)
        {
            zid.position = new Vector3(zid.position.x - 0.05f, zid.position.y, 0);
            volume.value = 0f;
        }
    }
}
