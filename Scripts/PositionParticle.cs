using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionParticle : MonoBehaviour
{
    public Transform firepos;
    public Transform particlepos;

    private void FixedUpdate()
    {
        particlepos.transform.position = firepos.transform.position; 
    }
}
