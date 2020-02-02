using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    // Start is called before the first frame update

    public bool plantFixed = true;    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Water")
        {
            plantFixed = true;
        }
    }
}
