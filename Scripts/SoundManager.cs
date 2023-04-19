using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public bool muted;
    public bool musicOn;
    [SerializeField] AudioSource src;
    [SerializeField] public AudioSource music;

    private void Awake()
    {
        if (instance == null) // sprijecava spawnanje vise SoundManagera nego potrebno
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicOn = true;
        }
        else
        {
            Destroy(gameObject);
        }

        gameObject.tag = "SoundManager";

    }
}
