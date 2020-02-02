using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

// Reference: https://www.youtube.com/watch?v=HnzmnSqE-Bc&list=PLmc6GPFDyfw-zhd2OA6tE9nDYeJUmA8rW

public class PlayerHand : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction = null;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;

    private InteractableObject currentInteractable = null;
    public List<InteractableObject> contactInteractables = new List<InteractableObject>();

    // Start is called before the first frame update
    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Down
        if (grabAction.GetStateDown(pose.inputSource))
        {
            print(pose.inputSource + "Trigger Down");
            Pickup();
        }


        // Up
        if (grabAction.GetStateUp(pose.inputSource))
        {
            print(pose.inputSource + "Trigger Up");
            Drop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        contactInteractables.Add(other.gameObject.GetComponent<InteractableObject>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
            return;

        contactInteractables.Remove(other.gameObject.GetComponent<InteractableObject>());
    }

    public void Pickup()
    {
        // Get nearest
        currentInteractable = GetNearestInteractable();

        // Null check
        if (!currentInteractable)
            return;

        // Already held check
        if(currentInteractable.activeHand)
            currentInteractable.activeHand.Drop();

        //// Position
        //currentInteractable.transform.position = transform.position;

        // Attach
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        joint.connectedBody = targetBody;

        // Set active hand
        currentInteractable.activeHand = this;
    }

    public void Drop()
    {
        // Null check
        if (!currentInteractable)
            return;

        // Apply velocity
        Rigidbody targetBody = currentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = pose.GetVelocity();
        targetBody.angularVelocity = pose.GetAngularVelocity();

        // Detach
        joint.connectedBody = null;

        // Clear
        currentInteractable.activeHand = null;
        currentInteractable = null;
    }

    private InteractableObject GetNearestInteractable()
    {
        InteractableObject nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(InteractableObject interactable in contactInteractables)
        {
            if(!interactable)
                continue;
            distance = (interactable.transform.position - transform.position).sqrMagnitude;

            if(distance<minDistance)
            {
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }
}
