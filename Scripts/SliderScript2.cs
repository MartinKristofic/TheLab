using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript2 : MonoBehaviour
{
    public Slider sliderZaKonzistenciju;

    public TextMeshProUGUI textZaKonzistenciju;

    public GameObject atom;

    public int numberOfAtoms;

    public GameObject[] activeAtoms;

    void Start()
    {
        numberOfAtoms = 0;
    }

    private void FixedUpdate()
    {
        textZaKonzistenciju.text = sliderZaKonzistenciju.value.ToString();
        activeAtoms = GameObject.FindGameObjectsWithTag("Atom2");

        if (int.Parse(textZaKonzistenciju.text) != activeAtoms.Length && activeAtoms.Length < int.Parse(textZaKonzistenciju.text))
        {
            Instantiate(atom, new Vector2(0, 0), Quaternion.identity);
        }
        else if (int.Parse(textZaKonzistenciju.text) != activeAtoms.Length && activeAtoms.Length > int.Parse(textZaKonzistenciju.text))
        {
            Destroy(activeAtoms[activeAtoms.Length - 1]);
        }
    }
}
