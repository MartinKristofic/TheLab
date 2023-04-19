using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript1 : MonoBehaviour
{
    public AudioSource src;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
        src = new AudioSource(); // zbog ove linije koda sam proveo 3 sata na stack overflowu xD
        src = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!soundManager.muted)
        {
            src.Play();
        }

        Invoke("ExitScene", 0.05f);
    }

    private void ExitScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
