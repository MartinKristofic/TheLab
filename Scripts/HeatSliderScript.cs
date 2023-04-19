using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatSliderScript : MonoBehaviour
{
    public AtomBehaviour atom;
    public AtomBehaviour2 atom2;

    public GameObject[] atoms;
    public GameObject[] atoms2;

    public Slider slider;

    public void FixedUpdate()
    {
        atoms = GameObject.FindGameObjectsWithTag("Atom");
        atoms2 = GameObject.FindGameObjectsWithTag("Atom2");

        foreach (GameObject atomic in atoms)
        {
            atomic.GetComponent<AtomBehaviour>().speed = slider.value;
        }

        foreach (GameObject atomic in atoms2)
        {
            atomic.GetComponent<AtomBehaviour2>().speed = slider.value;
        }
    }
}
