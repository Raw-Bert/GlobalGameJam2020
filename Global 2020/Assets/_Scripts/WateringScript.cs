using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem system;

    void Start()
    {

        system = Instantiate(system);

        system.gameObject.transform.parent = transform; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = multiVec3(transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 vecDown = transform.forward.normalized;

        float angle = Mathf.Acos(Dot(forward, vecDown) / (forward.magnitude * vecDown.magnitude)) * 180 / Mathf.PI;

        if (angle > 25.0f && vecDown.y < 0.0f)
        {
            system.gameObject.SetActive(true);

        }

        else
            system.gameObject.SetActive(false);


        system.transform.position = transform.position;


    }

    private Vector3 multiVec3(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);

    float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }
}
