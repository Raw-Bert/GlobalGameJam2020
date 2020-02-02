using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject plantSpawner;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button")
        {
            //if (plantSpawner.GetComponent<MakeCube>().plantFixed == true)
            //{
            plantSpawner.GetComponent<MakeCube>().spawnPlant = true;
            //    plantSpawner.GetComponent<MakeCube>().plantFixed = false;
            //}
        }
    }
}
