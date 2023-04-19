using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsScript : MonoBehaviour
{
    public GameObject ElementArea;
    public GameObject SettingsArea;

    public GameObject fire;
    public GameObject fireparticles;

    public int counter = 0;

    private void OnMouseDown()
    {
        if (counter == 0)
        {
            ElementArea.SetActive(true);
            SettingsArea.SetActive(false);
            counter++;

            fire.SetActive(false);
            fireparticles.SetActive(false);
        }
        else if (counter == 1)
        {
            ElementArea.SetActive(false);
            counter = 0;

            fire.SetActive(true);
            fireparticles.SetActive(true);
            fire.transform.position = Vector3.zero;
            fireparticles.transform.position = Vector3.zero;
        }
    }
}
