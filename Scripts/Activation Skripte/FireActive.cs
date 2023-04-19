using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireActive : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject frameLi;
    public GameObject frameWater;
    public GameObject frameHydro;
    public GameObject frameNeon;
    public GameObject frameOxy;
    public GameObject frameIce;
    public GameObject frameFire;
    public GameObject frameEraser;
    public GameObject frameElec;

    private void OnMouseDown()
    {
        gameManager.fireON = true;
        gameManager.fire.SetActive(true);

        frameFire.SetActive(true);

        frameWater.SetActive(false);
        frameHydro.SetActive(false);
        frameLi.SetActive(false);
        frameNeon.SetActive(false);
        frameIce.SetActive(false);
        frameEraser.SetActive(false);
        frameElec.SetActive(false);
        frameOxy.SetActive(false);

        gameManager.iceON = false;
        gameManager.elecON = false;
        gameManager.eraserON = false;

        gameManager.neonON = false;
        gameManager.waterON = false;
        gameManager.hydrogenON = false;
        gameManager.lithiumON = false;
        gameManager.oxygenON = false;
    }
}
