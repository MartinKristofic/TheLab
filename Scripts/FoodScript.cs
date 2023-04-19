using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private GameManager gameManager;
    public BoxCollider2D boxCol;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gameManager.foodbc == true)
        {
            boxCol.isTrigger = true;
        }
        else
        {
            boxCol.isTrigger = false;
        }
    }
}
