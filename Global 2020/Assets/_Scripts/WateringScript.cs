using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringScript : MonoBehaviour
{
    public ParticleSystem system;

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = multiVec3(transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 vecDown = transform.forward;

        float angle = Mathf.Acos(Dot(forward, vecDown) / (forward.magnitude * vecDown.magnitude)) * 180 / Mathf.PI;

        if (angle > 25 && vecDown.y < 0)

            system.Play();
        else
            system.Stop();
    }

    private Vector3 multiVec3(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);

    float Dot(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }
}
