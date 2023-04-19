using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenTrigger : MonoBehaviour
{
    public GameObject main;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Exploded")
        {
            main.tag = "Exploded";
            main.GetComponent<HydrogenBehaviour>().HydroKaboom();
        }
    }
}
