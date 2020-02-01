using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{

    [Range(-10, 10)] public float speed = 1;
    public float centerWidth = 1;
    public bool play;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }


    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        play = true;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>

    private void OnCollisionStay(Collision other)
    {

        var otherRB = other.gameObject.GetComponent<Rigidbody>();
        var otherTrans = other.transform;
        if (otherRB)
        {
            //if (InRange(otherTrans.position, transform.position - transform.forward * centerWidth, transform.position + transform.forward * centerWidth))
            //{
            //    play = false;
            //}
            if (play)
                otherRB.velocity = speed * transform.forward;
        }
    }

//public static  bool operator<=(Vector3 a,Vector3 b)=> a.magnitude >= 

    private bool InRange(Vector3 check, Vector3 low, Vector3 high) => check.magnitude - low.magnitude <= check.magnitude - high.magnitude;


}
