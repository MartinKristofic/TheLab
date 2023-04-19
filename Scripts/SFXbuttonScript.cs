using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SFXbuttonScript : MonoBehaviour
{
    private GameObject soundManager;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager"); // pronalazi SoundManager
        ButtonChangeText();
    }

    private void OnMouseDown()
    {
        if (!soundManager.GetComponent<SoundManager>().muted)
        {
            soundManager.GetComponent<SoundManager>().muted = true;
        }
        else
        {
            soundManager.GetComponent<SoundManager>().muted = false;
        }

        ButtonChangeText();
    }

    private void ButtonChangeText() // mijenja button text na ON/OFF
    {
        if (!soundManager.GetComponent<SoundManager>().muted)
        {
            buttonText.text = "ON";
            buttonText.color = Color.green;
        }
        else
        {
            buttonText.text = "OFF";
            buttonText.color = Color.red;
        }
    }
}
