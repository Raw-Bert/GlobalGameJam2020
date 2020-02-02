using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardboardBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetChild(0).tag == "Plant")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
