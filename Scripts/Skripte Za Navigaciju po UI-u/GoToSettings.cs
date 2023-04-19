using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSettings : MonoBehaviour
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

        Invoke("Continue", 0.15f);
    }

    private void Continue()
    {
        SceneManager.LoadScene(8);
    }
}
