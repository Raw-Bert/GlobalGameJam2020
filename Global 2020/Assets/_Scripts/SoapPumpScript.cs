using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapPumpScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

        if (transform.position.y < 0)
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -transform.position.y, 0), ForceMode.Impulse);

        else
        {
            transform.position = transform.parent.transform.position;
           transform.rotation = transform.parent.transform.rotation;
       
        }
    }
}
