using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 posStart;
    void Start()
    {
        posStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > posStart.y)
        {
            transform.position = posStart;
        }
    }
}
