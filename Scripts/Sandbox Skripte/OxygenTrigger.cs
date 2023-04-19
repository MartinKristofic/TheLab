using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenTrigger : MonoBehaviour
{
    [SerializeField] GameObject mainOxy;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Exploded")
        {
            mainOxy.tag = "Exploded";
            mainOxy.GetComponent<OxygenBehaviour>().BurnOxygen();
        }
    }
}
