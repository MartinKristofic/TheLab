using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityActive : MonoBehaviour
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
        gameManager.elecON = true;
        gameManager.elec.SetActive(true);

        frameElec.SetActive(true);

        frameWater.SetActive(false);
        frameHydro.SetActive(false);
        frameLi.SetActive(false);
        frameNeon.SetActive(false);
        frameFire.SetActive(false);
        frameEraser.SetActive(false);
        frameIce.SetActive(false);
        frameOxy.SetActive(false);

        gameManager.fireON = false;
        gameManager.iceON = false;
        gameManager.eraserON = false;

        gameManager.neonON = false;
        gameManager.waterON = false;
        gameManager.hydrogenON = false;
        gameManager.lithiumON = false;
        gameManager.oxygenON = false;
    }
}
