using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenActive : MonoBehaviour
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
        gameManager.oxygenON = true;

        frameOxy.SetActive(true);

        frameWater.SetActive(false);
        frameLi.SetActive(false);
        frameNeon.SetActive(false);
        frameIce.SetActive(false);
        frameFire.SetActive(false);
        frameEraser.SetActive(false);
        frameElec.SetActive(false);
        frameHydro.SetActive(false);

        gameManager.fireON = false;
        gameManager.iceON = false;
        gameManager.elecON = false;
        gameManager.eraserON = false;

        gameManager.neonON = false;
        gameManager.waterON = false;
        gameManager.lithiumON = false;
        gameManager.hydrogenON = false;
    }
}
