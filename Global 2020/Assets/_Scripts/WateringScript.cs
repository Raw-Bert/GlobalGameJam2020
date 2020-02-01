using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem system;

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.x < -20)
        
            system.Play();
        else
            system.Stop();
    }
}
