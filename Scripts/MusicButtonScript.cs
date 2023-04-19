using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicButtonScript : MonoBehaviour
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
        if (!soundManager.GetComponent<SoundManager>().musicOn)
        {
            soundManager.GetComponent<SoundManager>().musicOn = true;
            soundManager.GetComponent<SoundManager>().music.mute = false;
        }
        else
        {
            soundManager.GetComponent<SoundManager>().musicOn = false;
            soundManager.GetComponent<SoundManager>().music.mute = true;
        }

        ButtonChangeText();
    }

    private void ButtonChangeText() // mijenja button text na ON/OFF
    {
        if (soundManager.GetComponent<SoundManager>().musicOn)
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
