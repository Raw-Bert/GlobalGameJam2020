using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Reference: https://www.youtube.com/watch?v=vNqHRD4sqPc&list=PLmc6GPFDyfw85CcfwbB7ptNVJn5BSBaXz&index=3
public class PlayerPointer : MonoBehaviour
{
    public float defaultLength = 5.0f;
    public GameObject dot;
    public VRInput vrInput;

    private LineRenderer lineRenderer = null;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = vrInput.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? defaultLength : data.pointerCurrentRaycast.distance;

        // Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        // Default
        Vector3 endPos = transform.position + (transform.forward * targetLength);

        // Or based on hit
        if (hit.collider != null)
            endPos = hit.point;

        // Set position of the dot
        dot.transform.position = endPos;

        // Set linearenderer
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPos);
    }

    private RaycastHit CreateRaycast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }
}
