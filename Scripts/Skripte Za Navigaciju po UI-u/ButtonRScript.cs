using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonRScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pageNum;
    [SerializeField] GameObject BL; // drugi 'left' button

    [SerializeField] public GameObject reactantA;
    [SerializeField] public GameObject reactantB;

    [SerializeField] public GameObject reactantAtext;
    [SerializeField] public GameObject reactantBtext;

    [SerializeField] public GameObject temperature;
    [SerializeField] public GameObject temperatureText;

    [SerializeField] public GameObject pressure;
    [SerializeField] public GameObject pressureText;

    [SerializeField] public GameObject sizeA;
    [SerializeField] public GameObject sizeAtext;

    [SerializeField] public GameObject sizeB;
    [SerializeField] public GameObject sizeBtext;

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        BL.SetActive(true);

        reactantA.SetActive(false);
        reactantB.SetActive(false);
        reactantAtext.SetActive(false);
        reactantBtext.SetActive(false);
        temperature.SetActive(false);
        temperatureText.SetActive(false);

        pressure.SetActive(true);
        pressureText.SetActive(true);
        sizeA.SetActive(true);
        sizeB.SetActive(true);
        sizeAtext.SetActive(true);
        sizeBtext.SetActive(true);

        pageNum.text = "2/2";
    }
}
