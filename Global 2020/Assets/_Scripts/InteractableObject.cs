using UnityEngine;

// Reference: https://www.youtube.com/watch?v=HnzmnSqE-Bc&list=PLmc6GPFDyfw-zhd2OA6tE9nDYeJUmA8rW

[RequireComponent(typeof(Rigidbody))]
public class InteractableObject : MonoBehaviour
{
    [HideInInspector]
    public PlayerHand activeHand = null;
}
