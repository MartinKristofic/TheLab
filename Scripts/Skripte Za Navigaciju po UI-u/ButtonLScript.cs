using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonLScript : MonoBehaviour
{
    [SerializeField] ButtonRScript buttonRS;

    [SerializeField] TextMeshProUGUI pageNum;
    [SerializeField] GameObject BR; // drugi 'right' button

    private void OnMouseDown()
    {
        gameObject.SetActive(false);
        BR.SetActive(true);

        buttonRS.reactantA.SetActive(true);
        buttonRS.reactantB.SetActive(true);
        buttonRS.reactantAtext.SetActive(true);
        buttonRS.reactantBtext.SetActive(true);
        buttonRS.temperature.SetActive(true);
        buttonRS.temperatureText.SetActive(true);

        buttonRS.pressure.SetActive(false);
        buttonRS.pressureText.SetActive(false);
        buttonRS.sizeA.SetActive(false);
        buttonRS.sizeB.SetActive(false);
        buttonRS.sizeAtext.SetActive(false);
        buttonRS.sizeBtext.SetActive(false);

        pageNum.text = "1/2";
    }
}
