using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameScript : MonoBehaviour
{
    public AudioSource src;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        src = new AudioSource();
        src = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!soundManager.muted)
        {
            src.Play();
        }

        Invoke("ExitGame", 0.05f);
    }

    private void ExitGame() // prva faza izlazka iz igre
    {
        Application.Quit();
    }
}
