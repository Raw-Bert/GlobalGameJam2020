using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractableObject : MonoBehaviour
{
    [HideInInspector]
    public PlayerHand activeHand = null;
}
