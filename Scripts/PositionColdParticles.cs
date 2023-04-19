using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionColdParticles : MonoBehaviour
{
    public Transform coldpos;
    public Transform particlecoldpos;

    private void FixedUpdate()
    {
        particlecoldpos.transform.position = coldpos.transform.position;
    }
}
