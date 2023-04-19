using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberOfOrganisamsSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI numberOfOrganismsOnScreen;

    private void FixedUpdate()
    {
        numberOfOrganismsOnScreen.text = slider.value.ToString();
    }
}
