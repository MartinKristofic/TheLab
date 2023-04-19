using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeatValueScript : MonoBehaviour
{
    public Slider heatSlider;

    public TextMeshProUGUI heatValue;

    private float editVal;

    private void FixedUpdate() // hocemo dostici range 0 - 550 Kelvina s postojecim range-om 0 - 5.5f
    {
         editVal = (int)(heatSlider.value * 100); // brutalni algoritmi (UwU)
         heatValue.text = editVal.ToString() + "K";
    }
}
